using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.DTO.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace CareerMonitoring.Infrastructure.Extensions.Aggregate {
    public class ImportFileAggregate : IImportFileAggregate {
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public ImportFileAggregate (IUnregisteredUserRepository unregisteredUserRepository,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper, IUserGroupRepository userGroupRepository, IGroupRepository groupRepository) {
            _unregisteredUserRepository = unregisteredUserRepository;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            _userGroupRepository = userGroupRepository;
            _groupRepository = groupRepository;
        }

        public async Task<string> UploadFileAndGetFullFileLocationAsync (IFormFile file) {
            if (file == null || file.Length < 0)
                throw new Exception ("File not selected");

            if (!Directory.Exists ("wwwroot")) {
                Directory.CreateDirectory ("wwwroot");
            }

            var path = Path.Combine (_hostingEnvironment.WebRootPath, file.FileName).ToLower ();

            if (!Directory.Exists (path)) {
                Directory.CreateDirectory (path);
            }

            string fullFileLocation = Path.Combine (path, file.FileName).ToLower ();

            using (var fileStream = new FileStream (fullFileLocation, FileMode.Create)) {
                await file.CopyToAsync (fileStream);
            }
            return fullFileLocation;
        }

        public async Task<IEnumerable<UnregisteredUserDto>> ImportExcelFileAndGetImportDataAsync (string fullFileLocation) {
            FileInfo fileInfo = new FileInfo (fullFileLocation);
            
            List<UnregisteredUserDto> importDataListDto = new List<UnregisteredUserDto> ();

            using (ExcelPackage package = new ExcelPackage (fileInfo)) {
                var workSheet = package.Workbook.Worksheets[1];
                int totalRows = workSheet.Dimension.Rows;

                List<UnregisteredUser> importDataList = new List<UnregisteredUser> ();

                for (int i = 2; i <= totalRows; i++) {
                    var importData = new UnregisteredUser ();
                    importData.SetName (workSheet.Cells[i, 1].Value.ToString ());
                    importData.SetSurname (workSheet.Cells[i, 2].Value.ToString ());
                    importData.SetEmail (workSheet.Cells[i, 3].Value.ToString ().ToLowerInvariant ());
                    importDataList.Add (importData);

                    importDataListDto.Add (_mapper.Map<UnregisteredUserDto> (importData));
                }

                await _unregisteredUserRepository.AddAllAsync (importDataList);
            }
            Directory.Delete (fileInfo.DirectoryName, true);
            return importDataListDto;
        }

        public async Task<IEnumerable<UnregisteredUserDto>> ImportExcelFileToGroupAndGetImportDataAsync(string fullFileLocation, int groupId)
        {
            FileInfo fileInfo = new FileInfo (fullFileLocation);
            
            List<UnregisteredUserDto> importDataListDto = new List<UnregisteredUserDto> ();

            using (ExcelPackage package = new ExcelPackage (fileInfo)) {
                var workSheet = package.Workbook.Worksheets[1];
                int totalRows = workSheet.Dimension.Rows;

                List<UnregisteredUser> importDataList = new List<UnregisteredUser> ();

                for (int i = 2; i <= totalRows; i++) {
                    var importData = new UnregisteredUser ();
                    importData.SetName (workSheet.Cells[i, 1].Value.ToString ());
                    importData.SetSurname (workSheet.Cells[i, 2].Value.ToString ());
                    importData.SetEmail (workSheet.Cells[i, 3].Value.ToString ().ToLowerInvariant ());
                    importDataList.Add (importData);

                    importDataListDto.Add (_mapper.Map<UnregisteredUserDto> (importData));
                }

                await _unregisteredUserRepository.AddAllAsync (importDataList);

                Group group = await _groupRepository.GetByIdAsync(groupId);
                foreach (var user in importDataList)
                {
                    await _userGroupRepository.AddUserAsync(new UserGroup{User = user,Group = group});
                }
            }
            Directory.Delete (fileInfo.DirectoryName, true);
            return importDataListDto;
        }
    }
}
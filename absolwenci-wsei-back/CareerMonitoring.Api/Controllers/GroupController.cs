using System;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Commands.Account;
using CareerMonitoring.Infrastructure.Commands.ImportFile;
using CareerMonitoring.Infrastructure.Extensions.Aggregate.Interfaces;
using CareerMonitoring.Infrastructure.Services;
using CareerMonitoring.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerMonitoring.Api.Controllers
{
    [Authorize (Policy = "master")]
    public class GroupController:ApiUserController
    {
        private readonly IGroupService _groupService;
        private readonly IImportFileAggregate _importFileFactory;


        public GroupController(IGroupService groupService,IImportFileAggregate importFileFactory)
        {
            _groupService = groupService;
            _importFileFactory = importFileFactory;
        }

        [HttpGet ("Groups")]
        public async Task<IActionResult> GetGroups () {
            try{
                return Json(await _groupService.GetAllAsync());
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpPost ("Groups")]
        public async Task<IActionResult> CreateGroup ([FromBody]CreateGroup command) {
            try
            {
                if (await _groupService.ExistsByNameAsync(command.name))
                    return BadRequest("Group already exists");
                return Json (await _groupService.CreateAsync(command.name));
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpGet ("Groups/{id}")]
        public async Task<IActionResult> GetGroup (int id) {
            try
            {
                return Json(await _groupService.GetByIdAsync(id));
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpDelete ("Groups/{id}")]
        public async Task<IActionResult> DeleteGroup (int id) {
            try
            {
                await _groupService.DeleteAsync(id);
                return Ok();
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpPut ("Groups/{id}/user/{userId}")]
        public async Task<IActionResult> AddUser (int id, int userId) {
            try
            {
                await _groupService.AddUserAsync(id, userId);
                return Ok();
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpDelete ("Groups/{id}/user/{userId}")]
        public async Task<IActionResult> DeleteUser (int id, int userId) {
            try
            {
                await _groupService.RemoveUserAsync(id, userId);
                return Ok();
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
        [HttpPost ("Groups/{id}/file")]
        public async Task<IActionResult> AddUser (int groupId, [FromBody] ImportFile command) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            try
            {
                var fullFileLocation = await _importFileFactory.UploadFileAndGetFullFileLocationAsync (command.File);
                var importDataList = await _importFileFactory.ImportExcelFileToGroupAndGetImportDataAsync (fullFileLocation,groupId);
                return Json (importDataList);
            }
            catch(Exception e){
                return BadRequest (e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;
using CareerMonitoring.Infrastructure.DTO;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly ILinearScaleAnswerRepository _linearScaleAnswerRepository;
        private readonly IMultipleChoiceAnswerRepository _multipleChoiceAnswerRepository;
        private readonly IMultipleGridAnswerRepository _multipleGridAnswerRepository;
        private readonly IOpenQuestionAnswerRepository _openQuestionAnswerRepository;
        private readonly ISingleChoiceAnswerRepository _singleChoiceAnswerRepository;
        private readonly ISingleGridAnswerRepository _singleGridAnswerRepository;

        public AnswerService(IMapper mapper,
        IAnswerRepository answerRepository,
        ILinearScaleAnswerRepository linearScaleAnswerRepository,
        IMultipleChoiceAnswerRepository multipleChoiceAnswerRepository,
        IMultipleGridAnswerRepository multipleGridAnswerRepository,
        IOpenQuestionAnswerRepository openQuestionAnswerRepository,
        ISingleChoiceAnswerRepository singleChoiceAnswerRepository,
        ISingleGridAnswerRepository singleGridAnswerRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _linearScaleAnswerRepository = linearScaleAnswerRepository;
            _multipleChoiceAnswerRepository = multipleChoiceAnswerRepository;
            _multipleGridAnswerRepository = multipleGridAnswerRepository;
            _openQuestionAnswerRepository = openQuestionAnswerRepository;
            _singleChoiceAnswerRepository = singleChoiceAnswerRepository;
            _singleGridAnswerRepository = singleGridAnswerRepository;
        }

        public async Task CreateAsync(string questionType, int markedValue, ICollection<string> markedAnswers, string rowTitle, string colTitle, string answer, string markedAnswer)
        {
            switch(questionType)
            {
                case "linearScale":
                    await _linearScaleAnswerRepository.AddAsync (new LinearScaleAnswer(markedValue));
                break;
                case "multipleChoice":
                    await _multipleChoiceAnswerRepository.AddAsync (new MultipleChoiceAnswer (markedAnswers));
                break;
                case "multipleGrid":
                    await _multipleGridAnswerRepository.AddAsync (new MultipleGridAnswer (rowTitle, colTitle));
                break;
                case "openQuestion":
                    await _openQuestionAnswerRepository.AddAsync (new OpenQuestionAnswer (answer));
                break;
                case "singleChoice":
                    await _singleChoiceAnswerRepository.AddAsync (new SingleChoiceAnswer (markedAnswer));
                break;
                case "singleGrid":
                    await _singleGridAnswerRepository.AddAsync (new SingleGridAnswer (rowTitle, colTitle));
                break;
                default:
                    throw new Exception("invalid question type");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var answer = await _answerRepository.GetByIdAsync (id);
            await _answerRepository.DeleteAsync (answer);
        }

        public async Task<IEnumerable<AnswerDto>> GetAllForQuestionAsync(int questionId)
        {
            var answers = await _answerRepository.GetAllByQuestionIdAsync (questionId);
            return _mapper.Map<IEnumerable<AnswerDto>> (answers);
        }

        public async Task<AnswerDto> GetByIdAsync(int id)
        {
            var answer = await _answerRepository.GetByIdAsync (id);
            return _mapper.Map<AnswerDto> (answer);
        }
    }
}
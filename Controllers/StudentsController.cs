using System.Collections.Generic;
using AutoMapper;
using Boilerplate.Data.Contract;
using Boilerplate.Data.Mock;
using Boilerplate.Dtos.Student;
using Boilerplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        //private readonly MockStudentRepo _repository = new MockStudentRepo();
        public StudentsController(IStudentRepo repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get  api/Students
        [HttpGet]
        public ActionResult <IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var students = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        //Get  api/Students/5
        [HttpGet("{id}" , Name="GetStudentById")]
        public ActionResult <StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if(student != null){

                return Ok(_mapper.Map<StudentReadDto>(student));
            }
            return NotFound();
        }

        //Post  api/Students
        [HttpPost]
        public ActionResult<StudentCreateDto> CreateStudent( StudentCreateDto studnet)
        {
            var studentModel = _mapper.Map<Student>(studnet);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById) , new {id =studentReadDto.Id } , studentReadDto);
        }

        //put  api/Students/5
       [HttpPut("{id}")] 
       public ActionResult UpdateStudent(int id , StudentUpdateDto student)
       {
           var studentFromDB = _repository.GetStudentById(id);
           if(studentFromDB == null)
           {
               return NotFound();
           }
           _mapper.Map(student , studentFromDB);
           _repository.UpdateStudent(studentFromDB);
           _repository.SaveChanges();

           return NoContent();
       }

        //Delete  api/Students/5
       [HttpDelete("{id}")]
       public ActionResult DeleteStudent(int id)
       {
            var studentFromDB = _repository.GetStudentById(id);
            if(studentFromDB == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(studentFromDB);
            _repository.SaveChanges();

            return NoContent();
       }
    }
    
}
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.DTOs;
using AutoMapper;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private readonly IMapper _mapper;

        public StudentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/v1/Students
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDTO>> GetAll()
        {
            var studentDTO = _mapper.Map<IEnumerable<StudentReadDTO>>(students);
            return Ok(studentDTO);  // 200
        }

        // GET: api/v1/Students/1
        [HttpGet("{id}")]
        public ActionResult<StudentReadDTO> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404

            return Ok(_mapper.Map<StudentReadDTO>(student));
        }

        // POST: api/v1/Students
        [HttpPost]
        public ActionResult<StudentReadDTO> Create(StudentCreateDTO createDTO)
        {
            var student = _mapper.Map<Student>(createDTO);
            student.Id = students.Count + 1;

            students.Add(student);

            var readDTO = _mapper.Map<StudentReadDTO>(student);

            return CreatedAtAction(nameof(GetById),
                new { id = student.Id, version = "1.0" },
                readDTO); // 201
        }

        // PUT: api/v1/Students/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentUpdateDTO updateDTO)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404

            _mapper.Map(updateDTO, student);

            return NoContent(); // 204
        }

        // DELETE: api/v1/Students/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404

            students.Remove(student);
            return NoContent(); // 204
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace homework_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST: api/Student
        [HttpPost]
        public ActionResult<int> Post([FromBody] Student value)
        {
            value.Id = nextId++;
            students.Add(value);
            return Ok(value.Id); // Return the ID of the newly created student
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student value)
        {
            var studentIndex = students.FindIndex(s => s.Id == id);
            if (studentIndex == -1)
            {
                return NotFound();
            }
            students[studentIndex] = value;
            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            students.Remove(student);
            return NoContent();
        }

        // GET: api/Student/count
        [HttpGet("count")]
        public ActionResult<int> Count()
        {
            return students.Count;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PorchaAPI.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public PochtaRossiiContext db = new PochtaRossiiContext();
        [HttpGet("Users")]
        public async Task<List<User>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }
        [HttpGet("Roles")]
        public async Task<List<Role>> GetRoles()
        {
            return await db.Roles.ToListAsync();
        }
        [HttpGet("Buildings")]
        public async Task<List<Building>> GetBuildings()
        {
            return await db.Buildings.ToListAsync();
        }
        [HttpPost("PostUser")]
        public async Task<int> PostUser([FromBody] User user)
        {
            try
            {
                var postsUser = await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return postsUser.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }
        [HttpGet("PhoneBook")]
        public async Task<List<PhoneBook>> GetPhoneBook()
        {
            try
            {
                return await db.PhoneBooks.ToListAsync();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        [HttpGet("Task")]
        public async Task<List<Task>> GetTasks()
        {
            return await db.Tasks.ToListAsync();
        }
        [HttpGet("PaymentHumans")]
        public async Task<List<PaymentHuman>> GetPaymentHuman()
        {
            return await db.PaymentHumans.Include(x => x.IdApartamentNavigation).Include(s => s.IdApartamentNavigation.IdBuildingNavigation).ToListAsync();
        }
        [HttpGet("Login.login={login}.password={password}")]
        public async Task<User> GetUser([FromRoute] string login, [FromRoute] string password)
        {
            var userObj = await db.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
            return userObj;
        }
        [HttpGet("Payments")]
        public async Task<List<Payment>> GetPaymentList()
        {
            return await db.Payments.Include(x => x.IdHumanNavigation.IdApartamentNavigation.IdBuildingNavigation.IdRegionNavigation.Users).ToListAsync();
        }

        [HttpGet]
        [ActionName("PostDeletePhoneBook")]
        public async Task<IActionResult> GetDeletePhoneBook([FromRoute] int? id)
        {
            if (id != null)
            {
                PhoneBook PB = await db.PhoneBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (PB != null)
                    return View(PB);
            }
            return NotFound();
        }
        [HttpDelete("DeletePhone.id={id}")]
        public async Task<IActionResult> PostDeletePhoneBook([FromRoute] int? id)
        {
            if (id != null)
            {
                PhoneBook PB = await db.PhoneBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (PB != null)
                {
                    db.PhoneBooks.Remove(PB);
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPut("ChangeTask")]
        public async Task<bool> PutTask([FromBody] Task task)
        {
         
           
                db.Tasks.Update(task);
                await db.SaveChangesAsync();
                return true;
         
        }

        [HttpPost("AddNewPhoneBook")]
        public async Task<int> PostAddPB([FromBody] PhoneBook PBObj)
        {
            try
            {
                var pbjObj2 = await db.PhoneBooks.AddAsync(PBObj);
                await db.SaveChangesAsync();
                return PBObj.Id;
            }
            catch
            {
                return -1;
            }
        }
        [HttpPost("addNewPayments")]
        public async Task<bool> PostAddPayments([FromBody] Payment paymentCount)
        {
            await db.Payments.AddAsync(paymentCount);
            await db.SaveChangesAsync();
            return true;
        }
    }
}

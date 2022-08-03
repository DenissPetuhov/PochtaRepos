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
        [HttpGet("Apartaments.id={id}")]
        public async Task<List<Apartment>> GetApartaments([FromRoute] int id)
        {
            return await db.Apartments.Include(y => y.IdStatusBoxNavigation).Include(b => b.IdBuildingNavigation).Where(x => x.IdBuilding == id).ToListAsync();
        }
        [HttpGet("ApartamentsRegs.id={id}")]
        public async Task<List<Apartment>> GetApartamentsReg([FromRoute] int id)
        {
            return await db.Apartments.Include(x => x.IdBuildingNavigation).Include(y => y.IdStatusBoxNavigation).Where(b => b.IdBuildingNavigation.IdRegion == id).ToListAsync();
        }
        [HttpPut("UpdateApartaments")]
        public async Task<bool> PutApart([FromBody] Apartment aps)
        {
            db.Apartments.Update(aps);
            await db.SaveChangesAsync();
            return true;

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
            return await db.Tasks.Include(x => x.StatusTaskNavigation).ToListAsync();
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
        [HttpDelete("DeletePostman.id={id}")]
        public async Task<IActionResult> PostDeletePostman([FromRoute] int? id)
        {
            if (id != null)
            {
                User PB = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (PB != null)
                {
                    db.Users.Remove(PB);
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            return NotFound();
        }
        [HttpDelete("DeletePaument.id={id}")]
        public async Task<IActionResult> PostDeletePayjent([FromRoute] int? id)
        {
            if (id != null)
            {
                Payment PB = await db.Payments.FirstOrDefaultAsync(p => p.Id == id);
                if (PB != null)
                {
                    db.Payments.Remove(PB);
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
        [HttpPost("addNewTast")]
        public async Task<bool> PostAddTask([FromBody] Task taks)
        {
            await db.Tasks.AddAsync(taks);
            await db.SaveChangesAsync();
            return true;
        }

        [HttpDelete("DeleteTask.id={id}")]
        public async Task<IActionResult> PostDeleteTask([FromRoute] int? id)
        {
            if (id != null)
            {
                Task Ts = await db.Tasks.FirstOrDefaultAsync(p => p.Id == id);
                if (Ts != null)
                {
                    db.Tasks.Remove(Ts);
                    await db.SaveChangesAsync();
                    return Ok();
                }
              
            }
            return NotFound();
        }
    }
}

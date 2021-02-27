using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lession6.Models;

namespace Lession6
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactItemsController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactItemsController(ContactContext context)
        {
            _context = context;
        }

        // GET: api/ContactItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactItemDTO>>> GetContactItems()
        {
            return await _context.ContactItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/ContactItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactItemDTO>> GetContactItem(long id)
        {
            var contactItem = await _context.ContactItems.FindAsync(id);

            if (contactItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(contactItem);
        }

        // PUT: api/ContactItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactItem(long id, ContactItemDTO contactItemDTO)
        {
            if (id != contactItemDTO.Id)
            {
                return BadRequest();
            }

            // 驗證實際資料是否存在
            var contactItem = await _context.ContactItems.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }

            contactItem.Id = contactItemDTO.Id;
            contactItem.Customer = contactItemDTO.Customer;
            contactItem.Country = contactItemDTO.Country;
            contactItem.BusinessType = contactItemDTO.BusinessType;
            contactItem.BusinessOthers = contactItemDTO.BusinessOthers;
            contactItem.MainProducts = contactItemDTO.MainProducts;
            contactItem.Company = contactItemDTO.Company;
            contactItem.FirstName = contactItemDTO.FirstName;
            contactItem.LastName = contactItemDTO.LastName;
            contactItem.BusinessTitle = contactItemDTO.BusinessTitle;
            contactItem.Email = contactItemDTO.Email;
            contactItem.Telephone1 = contactItemDTO.Telephone1;
            contactItem.Telephone2 = contactItemDTO.Telephone2;
            contactItem.Telephone3 = contactItemDTO.Telephone3;
            contactItem.Comments = contactItemDTO.Comments;

            //_context.Entry(contactItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContactItem>> CreateContactItem(ContactItemDTO contactItemDTO)
        {
            var contactItem = new ContactItem
            {
                Customer = contactItemDTO.Customer,
                Country = contactItemDTO.Country,
                BusinessType = contactItemDTO.BusinessType,
                BusinessOthers = contactItemDTO.BusinessOthers,
                MainProducts = contactItemDTO.MainProducts,
                Company = contactItemDTO.Company,
                FirstName = contactItemDTO.FirstName,
                LastName = contactItemDTO.LastName,
                BusinessTitle = contactItemDTO.BusinessTitle,
                Email = contactItemDTO.Email,
                Telephone1 = contactItemDTO.Telephone1,
                Telephone2 = contactItemDTO.Telephone2,
                Telephone3 = contactItemDTO.Telephone3,
                Comments = contactItemDTO.Comments,
                CreateDate = DateTime.Now
            };

            _context.ContactItems.Add(contactItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetContactItem", new { id = contactItem.Id }, contactItem);
            
            return CreatedAtAction(
                nameof(GetContactItem),
                new { id = contactItem.Id },
                ItemToDTO(contactItem));

        }

        // DELETE: api/ContactItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactItem>> DeleteContactItem(long id)
        {
            var contactItem = await _context.ContactItems.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }

            _context.ContactItems.Remove(contactItem);
            await _context.SaveChangesAsync();

            return contactItem;
        }

        private bool ContactItemExists(long id)
        {
            return _context.ContactItems.Any(e => e.Id == id);
        }

        private static ContactItemDTO ItemToDTO(ContactItem contactItem) =>
            new ContactItemDTO
            {
                Id = contactItem.Id,
                Customer = contactItem.Customer,
                Country = contactItem.Country,
                BusinessType = contactItem.BusinessType,
                BusinessOthers = contactItem.BusinessOthers,
                MainProducts = contactItem.MainProducts,
                Company = contactItem.Company,
                FirstName = contactItem.FirstName,
                LastName = contactItem.LastName,
                BusinessTitle = contactItem.BusinessTitle,
                Email = contactItem.Email,
                Telephone1 = contactItem.Telephone1,
                Telephone2 = contactItem.Telephone2,
                Telephone3 = contactItem.Telephone3,
                Comments = contactItem.Comments
                // contactItem.CreateDate
                // contactItem.AdminNotes
            };

    }
}



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly MainDbContext _context;

    public InvoicesController(MainDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(int page = 1, int pagesize = 10,
        InvoiceStatus? status = null)
    {
        if (_context.Invoices == null)
        {
            return NotFound();
        }

        return await _context.Invoices.AsQueryable()
            .Include(x => x.InvoiceItems)
            .Where(x => status == null || x.Status == status)
            .OrderByDescending(x => x.InvoiceDate)
            .Skip((page - 1) * pagesize)
            .Take(pagesize)
            .AsSplitQuery()
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetInvoice(Guid id)
    {
        if (_context.Invoices == null)
        {
            return NotFound();
        }

        //var invoice = await _context.Invoices.FindAsync(id);
        var invoice = await _context.Invoices.Include(x => x.InvoiceItems).SingleOrDefaultAsync(x => x.Id == id);

        if (invoice == null)
        {
            return NotFound();
        }

        return invoice;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInvoice(Guid id, Invoice invoice)
    {
        if (id != invoice.Id)
        {
            return BadRequest();
        }

        //_context.Entry(invoice).State = EntityState.Modified;

        try
        {
            var invoiceToUpdate = await _context.Invoices.FindAsync(id);
            if (invoiceToUpdate == null)
            {
                return NotFound();
            }
            // invoiceToUpdate.InvoiceNumber = invoice.InvoiceNumber;
            // invoiceToUpdate.ContactName = invoice.ContactName;
            // invoiceToUpdate.Description = invoice.Description;
            // invoiceToUpdate.Amount = invoice.Amount;
            // invoiceToUpdate.InvoiceDate = invoice.InvoiceDate;
            // invoiceToUpdate.DueDate = invoice.DueDate;
            // invoiceToUpdate.Status = invoice.Status;

            // Update only the properties that have changed
            _context.Entry(invoiceToUpdate).CurrentValues.SetValues(invoice);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceExists(id))
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

    [HttpPost]
    public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
    {
        if (_context.Invoices == null)
        {
            return Problem("Entity set 'InvoiceDbContext.Invoices' is null.");
        }

        _context.Invoices.Add(invoice);

        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(Guid id)
    {
        if (_context.Invoices == null)
        {
            return NotFound();
        }

        var invoice = await _context.Invoices.FindAsync(id);

        if (invoice == null)
        {
            return NotFound();
        }

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InvoiceExists(Guid id)
    {
        return (_context.Invoices?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
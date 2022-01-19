using AgendaDemoBackend.Models;
using AgendaDemoBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaDemoBackend.Services;

public class ContactService
{
    private readonly ContactContext _context;
    public ContactService(ContactContext context)
    {
        _context = context;
    }
    public IEnumerable<Contact> GetAll() =>
        _context.Contacts.AsNoTracking().ToList();
    public Contact? GetById(Guid id) =>
        _context.Contacts.AsNoTracking()
            .SingleOrDefault(p => p.Id.Equals(id));
    public Contact? Create(Contact newContact)
    {
        _context.Contacts.Add(newContact);
        _context.SaveChanges();

        return newContact;
    }
    public void Update(Contact contactToUpdate)
    {
        _context.Contacts.Update(contactToUpdate);
        _context.SaveChanges();
    }
    public void DeleteById(Guid id)
    {
        var contactToDelete = _context.Contacts.Find(id);
        if(contactToDelete is not null)
        {
            _context.Contacts.Remove(contactToDelete);
            _context.SaveChanges();
        }
    }
}
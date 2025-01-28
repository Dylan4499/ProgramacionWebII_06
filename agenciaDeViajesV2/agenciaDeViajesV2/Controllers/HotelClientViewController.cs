using agenciaDeViajesV2.Data;
using Microsoft.AspNetCore.Mvc;
using agenciaDeViajesV2.Models;
using Microsoft.EntityFrameworkCore;

public class HotelClientViewController : Controller
{
    private readonly ApplicationDbContext _context;

    public HotelClientViewController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        
        var hoteles = _context.Hotels.Where(h => h.states == 1).ToList();

        return View(hoteles);
    }

    public IActionResult DetalleHotel(int id)
    {
        var hotel = _context.Hotels
            .Include(h => h.Room)
            .FirstOrDefault(h => h.PK_hotel == id && h.states == 1);

        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }

}

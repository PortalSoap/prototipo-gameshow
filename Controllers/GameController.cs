using Microsoft.AspNetCore.Mvc;
using ButtonBattle.Data;

namespace ButtonBattle.Controllers;

public class GameController : Controller
{
    private readonly ButtonBattleDbContext _dbContext;

    public GameController(ButtonBattleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult MainMenu()
    {
        return View();
    }

    public IActionResult Themes()
    {
        return View();
    }

    public IActionResult NewTheme()
    {
        return View();
    }

    public IActionResult NewQuestion()
    {
        return View();
    }

    public IActionResult Question()
    {
        return View();
    }
}
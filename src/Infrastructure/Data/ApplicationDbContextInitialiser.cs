using System.Runtime.InteropServices;
using MacClientSystem.Domain.Constants;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MacClientSystem.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        // var administrator =
        //     new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost", AccountId = 1};
        //
        // var account =
        //     new Account { Id = 1, Title = "Admin"};
        //
        // if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        // {
        //     await _userManager.CreateAsync(administrator, "Administrator1!");
        //     if (!string.IsNullOrWhiteSpace(administratorRole.Name))
        //     {
        //         await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        //     }
        // }
        //
        // if (_context.Accounts.All(u => u.Id != 1))
        // {
        //     await _context.Accounts.AddAsync(account);
        // }

        // if (!_context.Countries.Any())
        // {
            // CountryTitles
            // أثيوبيا;Ethiopia
            // أرمينيا;Armenia
            // إريتريا;Eritrea
            // أسبانيا;Spain
            // أفغانستان;Afghanistan
            // ألبانيا;Albania
            // ألمانيا;Germany
            // أمريكا;USA
            // أندونيسيا;Indonesia
            // أوروبا;Europe
            // أوزبكستان;Uzbekistan
            // أوكرانيا;Ukraine
            // إيرلندا;Ireland
            // اذربيجان;Azerbaijan
            // استرالي;Australian
            // الأرجنتين;Argentina
            // الإكوادور;Ecuador
            // الأوروغواي;Uruguay
            // الاردن;Jordan
            // الامارات;UAE
            // البحرين;Bahrain
            // البرازيل;Brazil
            // البرتغال;Portugal
            // الجزائر;Algeria
            // الدنمارك;Denmark
            // السعودية;KSA
            // السنغال;Senegal
            // السودان;Sudan
            // السويد;Sweden
            // الصومال;Somalia
            // الصين;China
            // العراق;Iraq
            // الفلبين;Philippines
            // الكاميرون;Cameroon
            // الكونغو;CONGO
            // الكويت;Kuwait
            // المجر;Hungary
            // المغرب;Morocco
            // المكسيك;Mexico
            // المملكة المتحدة;United Kingdom
            // النرويج;Norway
            // النمسا;Austria
            // النيجر;Niger
            // الهند;India
            // اليابان;Japan
            // اليمن;Yemen
            // اليونان;Greece
            // انغولا;Angola
            // اوغندا;Uganda
            // ايران;IRAN
            // ايسلندا;Iceland
            // ايطاليا;Italy
            // باكستان;Pakistan
            // بريطانيا - المملكة المتحدة;Britain - UK
            // بلجيكا;Belgium
            // بلغاريا;Bulgaria
            // بنجلاديش;Bangladesh
            // بنين;Benin
            // بولندا;Poland
            // بيرو;Peru
            // تايلاند;Thailand
            // تايوان;Taiwan
            // تركيا;Turkey
            // تشاد;Chad
            // تشيلي;Chile
            // تنزانيا;Tanzania
            // تونس; Tunisian
            // جامبيا;Gambia
            // جزر القمر;Comoros
            // جُمْهُوريَّةُ فِنْلَنْدَا;Finland
            // جمهورية الدومينيكان;Dominican Republic
            // جمهورية القمر المتحدة;Union De Comores
            // جمهورية موريشيوس;Republic of Mauritius
            // جنوب افريقيا;South Africa
            // جنوب السودان;South Sudan
            // جورجيا;Georgia
            // جيبوتي;Djibouti
            // رواندا;Rwanda
            // روسيا البيضاء;Belarus
            // روسيا;Russia
            // رومانيا;Romania
            // زامبيا;Zambia
            // زيمبابوي;Zimbabwe
            // ساحل العاج;Ivory Coast
            // سانت كيتس ونيفس;ST.Kitts and Nevis
            // سانت كيتس ونيفيس;ST Kitts and Nevis
            // سانت لوسيا;Saint Lucia
            // سريلانكا;Sri Lanka
            // سلوفاكيا;Slovakia
            // سنغافورة;Singapore
            // سوريا;Syria
            // سويسرا;Switzerland
            // سيشل;Seychelles
            // صربيا;Serbia
            // طاجيكستان;Tajikistan
            // عمان;Oman
            // غانا;Ghana
            // غوانتانامو;Guantanamo
            // غيانا;Guyana
            // غينيا;Guinea
            // فانواتو;Vanuatu
            // فرنسا;France
            // فلسطين;Palestine
            // فنزويلا;Venezuela
            // فيتنام;Vietnam
            // قبرص;Cyprus
            // قطر;Qatar
            // قيرغيزستان;Kyrgyzstan
            // كازخستان;Kazakhstan
            // كرواتيا;Croatia
            // كندا;Canada
            // كوبا;Cuba
            // كوريا الجنوبية;South Korean
            // كوريا الشمالية;North Korea
            // كولومبيا;Colombia
            // كينيا;Kenya
            // لاتفيا;Latvijas Republika
            // لبنان;Lebenon
            // لوكسمبورغ;Luxembourg
            // ليبيا;Libya
            // مالاوي;Malawi
            // مالطا;Malta
            // مالي;Mali
            // ماليزيا;Malaysia
            // مدغشقر;Madagascar
            // مصر;Egypt
            // مقدونيا;Macedonia
            // منغوليا;Mongolia
            // موريتانيا;Mauritania
            // مولدوفا;Moldova
            // ميانمار;Myanmar
            // نيبال;Nepal
            // نيجيريا;Nigeria
            // نيوزيلندا;New Zealand
            // هايتي;Haiti
            // هولندا;Holland
            // هونغ كونغ;Hong Kong
            // _context.Countries.AddRange(new List<Country>()
            // {
                // new Country { Name = "أثيوبيا", NameEn = "Ethiopia", Code = "ET", RowStatus = RowStatus.Active },
                // new Country { Name = "أرمينيا", NameEn = "Armenia", Code = "AM", RowStatus = RowStatus.Active },
                // new Country { Name = "إريتريا", NameEn = "Eritrea", Code = "ER", RowStatus = RowStatus.Active },
                // new Country { Name = "أسبانيا", NameEn = "Spain", Code = "ES", RowStatus = RowStatus.Active },
                // new Country { Name = "أفغانستان", NameEn = "Afghanistan", Code = "AF", RowStatus = RowStatus.Active },
                // new Country { Name = "ألبانيا", NameEn = "Albania", Code = "AL", RowStatus = RowStatus.Active },
                // new Country { Name = "ألمانيا", NameEn = "Germany", Code = "DE", RowStatus = RowStatus.Active },
                // new Country { Name = "أمريكا", NameEn = "USA", Code = "US", RowStatus = RowStatus.Active },
                // new Country { Name = "أندونيسيا", NameEn = "Indonesia", Code = "ID", RowStatus = RowStatus.Active },
                // new Country { Name = "أوروبا", NameEn = "Europe", Code = "EU", RowStatus = RowStatus.Active },
                // new Country { Name = "أوزبكستان", NameEn = "Uzbekistan", Code = "UZ", RowStatus = RowStatus.Active },
                // new Country { Name = "أوكرانيا", NameEn = "Ukraine", Code = "UA", RowStatus = RowStatus.Active },
                // new Country { Name = "إيرلندا", NameEn = "Ireland", Code = "IE", RowStatus = RowStatus.Active },
                // new Country { Name = "اذربيجان", NameEn = "Azerbaijan", Code = "AZ", RowStatus = RowStatus.Active },
                // new Country() { CountryTitles = "البحرين;Bahrain", }
            // });
        // }

        // Default data
        // Seed, if necessary
        // if (!_context.TodoLists.Any())
        // {
        //     _context.TodoLists.Add(new TodoList
        //     {
        //         Title = "Todo List",
        //         Items =
        //         {
        //             new TodoItem { Title = "Make a todo list 📃" },
        //             new TodoItem { Title = "Check off the first item ✅" },
        //             new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
        //             new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
        //         }
        //     });

        // await _context.SaveChangesAsync();
        // }
    }
}

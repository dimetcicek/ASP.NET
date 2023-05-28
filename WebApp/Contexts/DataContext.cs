using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<TagEntity> Tags { get; set; }

    public DbSet<ProductTagEntity> ProductTags { get; set; }

    public DbSet<ContactFormEntity> ContactForms { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = "f0237b71-fe5d-40b5-af1a-f703e065998d",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Id = "12fddf82-afca-405b-9c7a-f827156eb4b1",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

        // We don't want to add an admin account here, instead the first registered user will become admin.
        /*
        var passwordHasher = new PasswordHasher<UserEntity>();
        var userEntity = new UserEntity
        {
            Id = "4b9ae07c-75ef-4582-bd11-2b17ca2e0a97",
            UserName = "admin@domain.com",
            NormalizedUserName = "ADMIN@DOMAIN.COM",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            ConcurrencyStamp = Guid.NewGuid().ToString(),

        };
        userEntity.PasswordHash = passwordHasher.HashPassword(userEntity, "BytMig123!");
        builder.Entity<UserEntity>().HasData(userEntity);
        

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userEntity.Id,
            RoleId = "f0237b71-fe5d-40b5-af1a-f703e065998d"
        });
        */

        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "new" },
            new TagEntity { Id = 2, TagName = "featured"},
            new TagEntity { Id = 3, TagName = "popular"}
        );

        builder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = 1, Title = "HyperX Cloud 2", Price = 119, ImageUrl = "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_80726870/fee_786_587_png/HYPERX-Cloud-II-Wireless---Tr%C3%A5dl%C3%B6st-Gamingheadset-f%C3%B6r-PC--PS4-%26-Nintendo-Switch", Description = "HyperX Cloud II Gaming Headset i rött och svart har en avancerad USB audio control box med inbyggt DSP ljudkort, detta stärker ljud och tal så att du får en optimal gaming upplevelse. Med virtual 7.1 surround sound i kombination med stängda kåpor upplever du en detaljrikedom du tidigare aldrig hört! Mikrofon och ljud har separata volymkontroller som gör det lätt att höja och sänka volymen oberoende av varandra. Kompatibelt med PC & Mac via USB och stereokompatibelt med PS4, Xbox One1 och mobil. " },
            new ProductEntity { Id = 2, Title = "Razer Deathadder", Price = 123, ImageUrl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSYnJyGs3FmYgpXDPlRqMFwRU86cUlY6PCE0gedPYcUeCnvTXYFoZfPOxoIVlGCTgifbnT72rKoctXdXEhKRWDyGrpWn8P2y2xxfBotAEOU0jeeCf0qRzmHSSCUfXd1aH9_VUva&usqp=CAc", Description = "Den här formen kommer från vår prisbelönta DeathAdder-ergonomi och är utformad för små till medelstora handstorlekar och är mångsidig nog för att passa de flesta greppstilar. Till nollkostnad för att bygga hållfasthet har chassit också kastat bort mer vikt så att du kan dra av enkla svepningar och spela under långa timmar i komfort.\r\n\r\nMed förbättrad taktilitet för skarpare och mer tillfredsställande klick aktiverar omkopplarna i denna lilla ergonomiska spelmus med en branschledande responstid på 0,2 millisekunder. Genom att använda en infraröd ljusstråle istället för fysisk kontakt för att registrera varje klick, tar denna form av aktivering bort behovet av avstängningsfördröjning och utlöser aldrig oavsiktliga klick, vilket ger dig närmare kontroll och felfri utförande. " },
            new ProductEntity { Id = 3, Title = "MSI GF63", Price = 1200, ImageUrl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqyp5LozRGVoVB47jxuVY0FQV4d55gzmijVDef8TPGFWWBEODjL1aqADg-r_vUDj5hLM83XgRq44jVIIvpcrma44d_FE7IAcyyDR6BK1pfx7-GF2TBqoQ&usqp=CAc", Description = "MSI GF63 Thin bärbar dator för gaming är byggd med både hållbarhet och prestanda i åtanke. Tack vare metallchassit och det långvariga batteriet kan du ta ditt spelande på språng utan att behöva oroa dig" },
            new ProductEntity { Id = 4, Title = "Glorious GMMK 2", Price = 79, ImageUrl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRn6vt-ynbab_gYnu59ovKYcf9m26C-fS3oMoDv4YvYWWnNluIBJFdKZe3WKa2WsUsVv57hpVBULm9Qcr4ouhoEIlIeyNeDLqyZJ9zwftuSI8JlAHVl4v68TcycE5WRbBzpnw&usqp=CAc", Description = "Varje detalj i GMMK 2 Pre-built från Glorius har noggrant utformats för att ge dig den ultimata skriv- och spelupplevelsen. Den anodiserade aluminiumramen ger en solid grund för de inkluderade double-shot keycapsen, som använder ett rent typsnitt som aldrig bleknar. Hotswap-stöd gör att användarna enkelt kan koppla in sin önskade switchar. Glorious linjära Fox-switchar och stabilisatorer är pre-lubed för att vara mjuka, och det tjocka interna skummaterialet säkerställer en förstklassig ljudkvalitet. " },
            new ProductEntity { Id = 5, Title = "MSI G2412", Price = 135, ImageUrl = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRhk2LD0zCMVYuQh7Tn4ScDBHkaTG8z4iRdps16e41PWFTRi2QxGRnlhPKiWB3POnhG1HogyH0kEj0zQ4LmglNMzkt1wzyAkyABkFuDDJrp7EusG14v04W7Mr33AuLrneJBeQ&usqp=CAc", Description = "G2412 från MSI är en bildskärm perfekt för gaming. G2412 gamingskärm har 23.8” och levererar hela 170 bilder per sekund med sin FreeSync Premium teknologi med en otroligt snabb responstid på endast 1ms. Bildskärmen har 16.7 miljoner färger, 1100:1 i kontrast och ett brett bildförhållande på 16:9 med en justerbar lutning på -5° ~ 20°." },
            new ProductEntity { Id = 6, Title = "Glorious Model O", Price = 59, ImageUrl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTwCW8aB33v_fsuHcPMsk999ZuffyecrPaOqKrCC5tEO4SUHXDPzg5B0YkdoMP3xkgfsXle90CJ27tBs_I1de6EqM8K9nZVQQ-JNMys5IRBkmISVTfwn_AF5fDi2Z51_6aqSNg&usqp=CAc", Description = "Model O är en solid mus som har egenskaper de flesta tillverkare bara drömmer om att få använda när de tillverkar gamingmöss. Nu tar dom steget upp till nästa nivå med en av de mest avancerade sensorer som någonsin konstruerats, deras egna BAMF-sensor. Model-O Wireless utnyttjar kraften i BAMF sensoren och det isiga, släta glidet från deras G-skates för att ge dig maximal kontroll, minimalt med friktion och noll fördröjning." },
            new ProductEntity { Id = 7, Title = "Logitech G PRO X", Price = 44, ImageUrl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSSA1T7g6EGImiCBiOhngW2vye9UiKz1otq2vZfPweJcytckNt2y67r9L5wxrsYDc79dOk92zcIEJXh7fy9EHku4oBlZ-DeLPYn1sRh7ewh6C8GFNQzOQ1xKcrXoBQNJy9G8A&usqp=CAc", Description = "Hör och låt som ett proffs med Logitech PRO X. Med Blue VOICE-mikrofonteknik och nästa generations 7.1-surroundljud. Det externa USB-ljudkortet ger dig högkvalitativ kristallklart ljud. Designat för turneringar med nedladdningsbara ljud EQ. " },
            new ProductEntity { Id = 8, Title = "Logitech G PRO ", Price = 62, ImageUrl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcR-Ia36fWUj3UynzprsqdYtaEyKvN6N6ABt3bt4z5_nXXr6lFIGWnhRQkIKLrjjRG-WTizzqnR_TdmhgOpK-q7nuMFSlbCbD6toYEEzPGPdtPb5mLEUe8jiQg&usqp=CAc", Description = "Byggt för proffsen, inifrån och ut. Med sin kompakta design utan numerisk knappsats frigör det mekaniska speltangentbordet Logitech G® PRO bordsyta för lågkänsliga musrörelser. Clicky-brytare i proffsklass ger hörbar återkoppling. Med programmerbar LIGHTSYNC RGB och inbyggt minne kan du lagra anpassade belysningsmönster för turneringar." },
            new ProductEntity { Id = 9, Title = "Steelseries QcK", Price = 13, ImageUrl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSzFXVTBEfegK4S687W39k16CHUJRCC-IeYLPAGquVEiMTjhJHgltLVsf3lhBRrRpS9Pb2xdrGtiXRTyHg83Ye7GxfamA9dqnHsonkyNqCnWcZTiZiZknLmG0Me-FtYso0Ftw&usqp=CAc", Description = "Extra bred musmatta med högkvalitativ ultravävd yta som har utmärkt glidförmåga, sydda kanter och halkskyddad undersida." }
        );

        builder.Entity<ProductTagEntity>().HasData(
            // New
            new ProductTagEntity { ProductId = 1, TagId = 1 }, 
            new ProductTagEntity { ProductId = 2, TagId = 1 }, 
            new ProductTagEntity { ProductId = 3, TagId = 1 }, 
            new ProductTagEntity { ProductId = 4, TagId = 1 },

            // Featured
            new ProductTagEntity { ProductId = 5, TagId = 2 }, 
            new ProductTagEntity { ProductId = 6, TagId = 2 }, 
            new ProductTagEntity { ProductId = 7, TagId = 2 }, 

            // Featured
            new ProductTagEntity { ProductId = 8, TagId = 3 },
            new ProductTagEntity { ProductId = 9, TagId = 3 }
        );
    }
}

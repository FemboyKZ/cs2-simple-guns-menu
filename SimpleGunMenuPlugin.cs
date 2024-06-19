using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;

namespace SimpleGunMenuPlugin;

[MinimumApiVersion(240)]
public partial class SimpleGunMenuPlugin : BasePlugin
{
    public override string ModuleName => "GunMenuPlugin";
    public override string ModuleVersion => "0.0.6-fix";
    public override string ModuleAuthor => "Constummer (Dots fix)";
    public override string ModuleDescription => "Gun Menu Plugin";

    public override void Load(bool hotReload)
    {
        AddCommand("css_guns", "Opens the gun menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu("Gun Menu");
        MenuHelper.GetGuns(gunMenu);
        MenuManager.OpenChatMenu(player, gunMenu);
        });

        AddCommand("css_weapons", "Opens the gun menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu("Gun Menu");
        MenuHelper.GetGuns(gunMenu);
        MenuManager.OpenChatMenu(player, gunMenu);
        });

        AddCommand("css_pistols", "Opens the pistol menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu($"{commandInfo.GetCommandString.Split(" ")[0]} Menu");
        MenuHelper.GetGuns(gunMenu, WeaponType.Secondary);
        MenuManager.OpenChatMenu(player, gunMenu);
        });

        AddCommand("css_secondary", "Opens the pistol menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu($"{commandInfo.GetCommandString.Split(" ")[0]} Menu");
        MenuHelper.GetGuns(gunMenu, WeaponType.Secondary);
        MenuManager.OpenChatMenu(player, gunMenu);
        });

        AddCommand("css_rifles", "Opens the rifle menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu($"{commandInfo.GetCommandString.Split(" ")[0]} Menu");
        MenuHelper.GetGuns(gunMenu, WeaponType.Primary);
        MenuManager.OpenChatMenu(player, gunMenu);
        });

        AddCommand("css_pirmary", "Opens the rifle menu", (player, commandInfo) =>
        {
        if (ValidatePlayer(player) == false || player == null)
        {
            return;
        }

        var gunMenu = new ChatMenu($"{commandInfo.GetCommandString.Split(" ")[0]} Menu");
        MenuHelper.GetGuns(gunMenu, WeaponType.Primary);
        MenuManager.OpenChatMenu(player, gunMenu);
        });
    }

    private static bool ValidatePlayer(CCSPlayerController? player)
    {
        if (player == null || player.IsBot || !player.IsValid)
        {
            return false;
        }

        if (player.PawnIsAlive == false)
        {
            player.PrintToChat("Only alive players can call this command");
            return false;
        }

        if(player.Team == CsTeam.Spectator) return false;
        if(player.Team == CsTeam.None) return false;

        return true;
    }
}

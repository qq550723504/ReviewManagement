using System.Threading.Tasks;
using EasyAbp.ReviewManagement.Localization;
using EasyAbp.ReviewManagement.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.ReviewManagement.Web.Menus
{
    public class ReviewManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<ReviewManagementResource>();
             //Add main menu items.

            if (await context.IsGrantedAsync(ReviewManagementPermissions.Review.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(ReviewManagementMenus.Review, l["Menu:Review"], "/ReviewManagement/Reviews/Review")
                );
            }
        }
    }
}

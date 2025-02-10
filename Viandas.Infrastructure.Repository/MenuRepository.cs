using Microsoft.EntityFrameworkCore;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Data.Db;
using Viandas.Infrastructure.Data.EntityModel;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Infrastructure.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDb _context;

        public MenuRepository(AppDb context)
        {
            _context = context;
        }

        public Menu GetMenuById(string menuID)
        {
            var found = _context.Menu.Find(menuID);

            if (found == null)
            {
                throw new NullReferenceException();
            }

            return found.MapToEntity();
        }

        public List<Menu> GetMenusBetweenTwoDates(DateTime firstDate, DateTime lastDate)
        {
            var menues = _context.Menu.Where(m => m.ConsumptionDate >= firstDate
                                               && m.ConsumptionDate <= lastDate)
                                        .Include(m => m.Options)
                                        .ToList();

            return menues.Select(m => m.MapToEntity()).ToList();
        }

        public Menu GetMenuWithOrders(string menuID)
        {
            var menu = _context.Menu
                               .Include(m => m.Options)
                                   .ThenInclude(o => o.OrderItemModels)
                               .Include(m => m.Responsible)
                               .Include(m => m.Orders)
                                   .ThenInclude(o => o.Items)
                               .Include(m => m.Orders)
                                   .ThenInclude(o => o.UserModel)
                               .FirstOrDefault(m => m.MenuID == menuID);

            if(menu == null)
            {
                throw new NullReferenceException();
            }

            return menu.MapToEntity();
        }


        public Menu InsertMenu(Menu menu)
        {
            var newMenu = new MenuModel().MapToModel(menu);

            _context.Menu.Add(newMenu);

            _context.SaveChanges();

            return menu;
        }

        public Menu UpdateMenu(Menu menu)
        {
            var existingMenu = _context.Menu.
                                        Local.
                                       FirstOrDefault(m => m.MenuID == menu.Id);

            if (existingMenu != null)
            {
                _context.Entry(existingMenu).State = EntityState.Detached;
            }

            var map = new MenuModel().MapToModel(menu);

            _context.Entry(map).State = EntityState.Modified;
            _context.SaveChanges();

            return menu;
        }
    }
}

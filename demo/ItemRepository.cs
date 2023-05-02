using demo.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace demo
{
    public class ItemRepository : IItemRepository
    {
        public ItemRepository() 
        { 
            using (var context = new ApiContext())
            {
                var items = new List<Item>();

               // var item = new Item
               // {
               //     UserId = 0,
               //     Category = "string",
               //     App = "string",
               //     UserName = "string",
               //     Password = "string"

               // };
                   
               // context.Items.Add(item);
                    
               //context.SaveChanges();
                
            }
        }

        public List<Item> GetItems()
        {
            using(var context = new ApiContext()) 
            {
                try
                {
                    var list = context.Items.ToList();
                    return list;

                }
                catch
                {
                    Console.WriteLine("In Get Items");
                    return null;
                }

            }
        }

        public List<Item> AddUser(Item item)
        {
            using(var context = new ApiContext())
            {
                Console.WriteLine(item);
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(item.Password);
                var encyptedPassword = System.Convert.ToBase64String(plainTextBytes);

                item.Password = encyptedPassword;

                try
                {
                    var user = context.Items.Add(item);
                }
                catch
                {
                    Console.WriteLine("In AddUSer");
                }

                context.SaveChanges();

                return context.Items.ToList();

            }
        }
        public Item GetUser(int id) 
        {
            using(var context = new ApiContext())
            {
                try
                {
                    var result = context.Items.Where(x => x.UserId == id).First();

                    if(result == null)
                    {
                        return null;
                        
                    }

                    return result;
                }
                catch
                {
                    Console.WriteLine("In Get User");
                    return null;
                }
            }
        }

        public Item UpdateUser(Item item)
        {
            using (var context = new ApiContext())
            {
                try
                {
                    var result = context.Items.Where(x => x.UserId == item.UserId).First();

                    if (result == null)
                    {
                        return context.Items.Where(x => x.UserId == 0).First();
                    }

                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(item.Password);
                    var encyptedPassword = System.Convert.ToBase64String(plainTextBytes);

                    result.Category = item.Category;
                    result.App = item.App;
                    result.UserName = item.UserName;
                    result.Password = encyptedPassword;

                    context.Entry(result).State= EntityState.Modified;
                    context.SaveChanges();
                    return result;
                }
                catch
                {
                    Console.WriteLine("In Update User");
                    return null;
                }
            }
        }
        public bool DeleteUser(int id) 
        {
            using(var context = new ApiContext())
            {
                try
                {
                    var result = context.Items.Where(x => x.UserId == id).First();

                    if (result == null)
                    {
                        return false;

                    }

                    context.Items.Remove(result);

                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    Console.WriteLine("In Delete User");
                    return false;
                }
            }
        }

    }
}

using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=CustomerOrderViewer;Integrated Security=True";
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(connString);

                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine(@$"Id: {customerOrderDetailModel.CustomerOrderId} Fullname: {customerOrderDetailModel.FirstName} {customerOrderDetailModel.LastName} - purchased: {customerOrderDetailModel.Description} for the price: {customerOrderDetailModel.Price}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong {ex.Message}.");
            }

            Console.ReadKey();
        }
    }
}

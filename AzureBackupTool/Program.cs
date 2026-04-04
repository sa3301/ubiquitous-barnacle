using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new AzureService();

        Console.WriteLine("1. Upload File");
        Console.WriteLine("2. List Files");
        Console.WriteLine("3. Download File");
        Console.WriteLine("4. Migrate File");
        Console.WriteLine("5. Auto Migrate All Files");

        Console.Write("Choose an option: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter file path: ");
                var path = Console.ReadLine();
                await service.UploadFileAsync(path);
                break;

            case "2":
                await service.ListFilesAsync();
                break;

            case "3":
                Console.Write("Enter file name: ");
                var name = Console.ReadLine();
                await service.DownloadFileAsync(name);
                break;

            case "4":
                Console.Write("Enter file path to migrate: ");
                var migratePath = Console.ReadLine();
                await service.MigrateFileAsync(migratePath);
                break;

            case "5":
                await service.AutoMigrateAllAsync();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
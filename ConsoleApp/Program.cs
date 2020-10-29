using System.Net.Http;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpclient = new HttpClient();
            using CancellationTokenSource tokenSource = new CancellationTokenSource(2_000);
            try
            {
                httpclient.GetAsync("https://google.com:4552", tokenSource.Token).GetAwaiter().GetResult(); //Отсутствие ответа от сервера не является ошибкой задания
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}

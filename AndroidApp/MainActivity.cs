using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Net.Http;
using System.Threading;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstace)
        {
            base.OnCreate(savedInstace);
            var httpclient = new HttpClient();
            using (CancellationTokenSource tokenSource = new CancellationTokenSource(2_000))
            {
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
            };
            SetContentView(Resource.Layout.activity_main);
        }
    }
}
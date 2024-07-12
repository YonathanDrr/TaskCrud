using System.Web;
using System.Web.Optimization;

namespace Ejercicio1
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                              "~/Scripts/jquery.validate*"));

        }
    }
}

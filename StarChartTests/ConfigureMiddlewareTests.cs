using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace StarChartTests
{
    public class ConfigureMiddlewareTests
    {
        [Fact(DisplayName = "Call AddControllers In ConfigureServices @call-addmvc-in-configureservices")] //TODO - rename this 
        public void CallAddControllersInProgramTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "StarChart" + Path.DirectorySeparatorChar + "Program.cs";
            Assert.True(File.Exists(filePath), "`Program.cs` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"builder.Services\s*?[.]AddControllers";
            var rgx = new Regex(pattern);

            Assert.True(rgx.IsMatch(file), "`Program.cs` didn't contain a call for `AddControllers` on `builder.Services`");
        }

        [Fact(DisplayName = "Call AddDbContext In ConfigureServices @call-adddbcontext-in-configureservices")]
        public void CallAddApplicationDbContextInProgramTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "StarChart" + Path.DirectorySeparatorChar + "Program.cs";
            Assert.True(File.Exists(filePath), "`Program.cs` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"builder.Services\s*?[.]AddDbContext\s*?[<]\s*?ApplicationDbContext\s*?[>]";
            var rgx = new Regex(pattern);

            Assert.True(rgx.IsMatch(file), "`Program.cs` didn't contain a call for `AddDbContext` on `builder.Services` with the type argument `ApplicationDbContext`");
            //This doesn't technically verify UseInMemoryDatabase was used as an argument for AddDbContext, however; this will allow for other acceptable ways to handle this task
            Assert.True(file.Contains("UseInMemoryDatabase"), @"`Startup.ConfigureServices` didn't provide `options => options.UseInMemoryDatabase(""StarChart"")` as an argument for `AddDbContext<ApplicationDbContext>`");
        }

        [Fact(DisplayName = "Call MapControllers In Configure @call-usemvc-in-configure")]
        public void CallMapControllersInProgramTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "StarChart" + Path.DirectorySeparatorChar + "Program.cs";
            Assert.True(File.Exists(filePath), "`Program.cs` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"app\s*?[.]MapControllers";
            var rgx = new Regex(pattern);

            Assert.True(rgx.IsMatch(file), "`Program.cs` didn't contain a call for `MapControllers` on `app`");
        }
    }
}

using System;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarker {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes => routes
                .MapRoute(
                   name: "default",
                   template: "{title}",
                   defaults: new { controller = "Home", action = "Index" }));
        }
    }

    public class HomeController : Controller {
        public IActionResult Index(string title) {
            return View(new Model {
                Title = title,
                Members = new[] {
                    new Member { Name = "Chris McCord" },
                    new Member { Name = "Matt Sears" },
                    new Member { Name = "David Stump" },
                    new Member { Name = "Ricardo Thompson" }
                },
            });
        }
    }

    public class Model {
        public string Title { get; set; }

        public Member[] Members { get; set; }
    }

    public class Member {
        public string Name { get; set; }
    }
}

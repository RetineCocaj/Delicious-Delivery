#pragma checksum "C:\Users\Asus\Desktop\FoodProject\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56008e11882a6a7f923b6b1afbcd8cb02cfc84a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Asus\Desktop\FoodProject\Views\_ViewImports.cshtml"
using FoodProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\FoodProject\Views\_ViewImports.cshtml"
using FoodProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56008e11882a6a7f923b6b1afbcd8cb02cfc84a2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2971d03854856c1b996622a1f584a550e827fd8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""jumbotron"" id=""home-jumbotron"">
    <h1>Delicious Delivery</h1>
    <p class=""lead"">Delicious Delivery is an online Food Ordering system, where users can view our Food items and make orders</p>
</div>

<div class=""row"">
    <div class=""col-md-4 index-nav-card"">
        <div class=""card-bg"">
            <h2>About us</h2>
            <p class=""text-justify"">
                Need quick and quality Meal but can't afford time to go out to buy or cook? <br />
                Delicious Delivery is an online Food Ordering system,
                where users can view our Food items and make orders
            </p>
            <p>
                ");
#nullable restore
#line 20 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Learn More", "About", "Home", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </p>
        </div>
        
    </div>
    <div class=""col-md-4 index-nav-card"">
        <div class=""card-bg"">
            <h2>Order It</h2>
            <p class=""text-justify"">
                Checkout our various Food Categories to select which to add to your cart. <br />
                Checkout is fast.
            </p>
            <p>
                ");
#nullable restore
#line 33 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Food Categories", "Category", "Home", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </p>
        </div>
        
    </div>
    <div class=""col-md-4 index-nav-card"">
        <div class=""card-bg"">
            <h2>Delivery</h2>
            <p class=""text-justify"">
                Our delivery system is top notch and as of now the fastest delivery in town,
                have you food delivered within 10 minutes of ordering.
            </p>
            <p>
                ");
#nullable restore
#line 46 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Index.cshtml"
           Write(Html.ActionLink("Checkout", "Checkout","ShoppingCart", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        \r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

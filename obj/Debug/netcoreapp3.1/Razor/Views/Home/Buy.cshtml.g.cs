#pragma checksum "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bec27ae555758e094388dcfdb59e7e6b0ef47c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Buy), @"mvc.1.0.view", @"/Views/Home/Buy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bec27ae555758e094388dcfdb59e7e6b0ef47c5", @"/Views/Home/Buy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2971d03854856c1b996622a1f584a550e827fd8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Buy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FoodProject.Models.FoodItem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
  
    ViewData["Title"] = "Buy";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Are you sure?</h2>\r\n\r\n<div>\r\n    <h4>Are you sure you want to add this Item to your Cart?</h4>\r\n    <hr />\r\n");
#nullable restore
#line 12 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
     using (Html.BeginForm("ConfirmBuy", "Home", FormMethod.Post))
    {

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
   Write(Html.HiddenFor(model => model.FoodItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\" name=\"returnUrl\"");
            BeginWriteAttribute("value", " value=\"", 365, "\"", 438, 1);
#nullable restore
#line 16 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
WriteAttributeValue("", 373, ViewBag.ReturnUrl == null ? "" : (ViewBag.ReturnUrl as string), 373, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <dl class=\"dl-horizontal d-flex justify-content-between flex-column\" style=\"width:250px;\">\r\n            <div class=\"d-flex justify-content-between\">\r\n                <dt class=\"mr-5\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n\r\n                <dd class=\"text-right\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
               Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </div>\r\n            <div class=\"d-flex justify-content-between\">\r\n                <dt class=\"mr-5\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
               Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n\r\n                <dd>\r\n                    ");
#nullable restore
#line 33 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
               Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </dd>
            </div>

            <div class=""d-flex justify-content-between"">
                <dt class=""mr-5"">
                    Quantity
                </dt>

                <dd class=""d-flex justify-content-end"">
                    <input class=""text-box single-line"" data-val=""true""
                    data-val-number=""The field Quantity must be a number."" )
                    data-val-range=""The field Quantity must be between 1 and 20 ."" ) data-val-range-max=20
                    data-val-range-min=""1"" id=""Quantity"" name=""Quantity"" type=""number"" value=""1"" style=""width: 60px;""/>
                </dd>
            </div>
        </dl>
");
            WriteLiteral("        <p class=\"d-flex justify-content-end\" style=\"width:20%\">\r\n            <input class=\"btn btn-success mr-1\" type=\"submit\" value=\"Confirm Buy\" />\r\n            ");
#nullable restore
#line 53 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
       Write(Html.ActionLink("Goto List", "All", null, null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n");
#nullable restore
#line 55 "C:\Users\Asus\Desktop\FoodProject\Views\Home\Buy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FoodProject.Models.FoodItem> Html { get; private set; }
    }
}
#pragma warning restore 1591

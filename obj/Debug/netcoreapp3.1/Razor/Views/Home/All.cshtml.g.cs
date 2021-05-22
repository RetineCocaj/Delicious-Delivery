#pragma checksum "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eee8558250cf612196a0bb072edfd175f25e8f86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_All), @"mvc.1.0.view", @"/Views/Home/All.cshtml")]
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
#nullable restore
#line 2 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eee8558250cf612196a0bb072edfd175f25e8f86", @"/Views/Home/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2971d03854856c1b996622a1f584a550e827fd8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FoodItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
  
    ViewData["Title"] = "All Food Items";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>All Food Items\r\n");
#nullable restore
#line 10 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
     if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
   Write(Html.ActionLink("", "AddItem", "Category", new { categoryId = ViewBag.CategoryId, returnUrl = @Url.Action() }, new
    { @class = "text-light", @id="addItemBtn"}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                                               
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<h5 class=\"text-danger\">");
#nullable restore
#line 17 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                   Write(TempData["NotLoggedIn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
 if (ViewBag.Message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-center text-success\">");
#nullable restore
#line 21 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                                    Write(ViewBag.Message as string);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 22 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-center text-danger\">");
#nullable restore
#line 25 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                                   Write(ViewBag.ErrorMessage as string);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 26 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table category-table\">\r\n    <tr>\r\n\r\n        <th>\r\n            ");
#nullable restore
#line 32 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            Category\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 38 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th>Cart Actions</th>\r\n");
#nullable restore
#line 42 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
         if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>Item Actions</th>\r\n");
#nullable restore
#line 45 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\r\n\r\n");
#nullable restore
#line 48 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
           Write(Html.DisplayFor(modelItem => item.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 61 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                 if (item.isEnabled == true)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
               Write(Html.ActionLink("Add To Cart", "Buy", new { id = item.FoodItemId, returnUrl = Url.Action() }, new {
            @class ="btn btn-primary" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                                        
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button disabled type=\"button\" class=\"btn btn-success\">Added to Cart</button>\r\n");
#nullable restore
#line 69 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
               Write(Html.ActionLink("Edit", "Edit", "ShoppingCart", new { cartItemId = item.CartItemId, returnUrl =
            Url.Action() },new { @class = "btn btn-primary mr-1" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
               Write(Html.ActionLink("Remove", "Remove", "ShoppingCart", new { cartItemId = item.CartItemId, returnUrl =
            Url.Action() }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
                                                              
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
#nullable restore
#line 76 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
             if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 79 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
               Write(Html.ActionLink("Edit", "EditItem", "Category", new { foodItemId = item.FoodItemId, returnUrl =
            Url.Action() }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 81 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
               Write(Html.ActionLink("Remove", "RemoveItem", "Category", new { foodItemId = item.FoodItemId, returnUrl =
            Url.Action() }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 84 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 86 "C:\Users\Asus\Desktop\FoodProject\Views\Home\All.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n\r\n<script>\r\n    $(document).ready(function(){\r\n        $(\'#addItemBtn\').append(\'<i class=\"fa fa-plus-circle ml-2\" style=\"font-size: 18pt;\" title=\"Click here to add an Item!\"></i>\');\r\n    });\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FoodItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591

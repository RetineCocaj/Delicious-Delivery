#pragma checksum "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93cfc2d0dce00b7530cd46ff431e7c818ffac7a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cfc2d0dce00b7530cd46ff431e7c818ffac7a1", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2971d03854856c1b996622a1f584a550e827fd8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<FoodProject.Models.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Orders</h2>

<div>
    <hr />
    
    <table class=""table category-table"">
        <tr>
            <th>
                Payment
            </th>

            <th>
                Items
            </th>
            <th>
                Order Date
            </th>
            <th>
                Destination
            </th>
            <th>Status</th>
        </tr>

");
#nullable restore
#line 30 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
         if ( Model != null && Model.Count > 0)
        {
            foreach (var order in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>\n                        ");
#nullable restore
#line 36 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => order.TotalAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n\n                    <td>\n");
#nullable restore
#line 40 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                         foreach (var item in order.Items)
                        {
                            var priceQuantity = item.Quantity * item.Price;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                       Write(Html.Raw(item.Name + " (x" + item.Quantity.ToString() + ")" + "<br />"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                                                                                                    
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\n                    <td>\n                        ");
#nullable restore
#line 47 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                   Write(order.OrderDate.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 50 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                   Write(order.Destination);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 53 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
                   Write(order.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("                    </td>\n                </tr>\n");
#nullable restore
#line 57 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
            }


        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"text-center\"><td colspan=\"4\"><h4>You have no Pending Orders at the moment.</h4> </td> </tr>\n");
#nullable restore
#line 64 "C:\Users\Asus\Desktop\FoodProject\Views\Order\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<FoodProject.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppForTest.Pages
{
    public class DropdownMultiselectModel : PageModel
    {
        public string OptionsList { get; set; }

        public void OnGet()
        {
            OptionsList =
                "<option value='1'>Eleman bir</option>"
    + "<option value = '2'>Eleman iki</option>"
     + "<option value = '4'>Eleman üç</option>"
          + "<option value = '8'>Eleman dört</option>"
               + "<option value = '16'>Eleman beş</option>";
        }

        /*********
         * <option value='1'>Item 1</option>
    <option value='2'>Item 2</option>
    <option value='3'>Item 3</option>
    <option value='4'>Item 4</option>
    <option value='5'>Item 5</option>
         * ****/
    }
}
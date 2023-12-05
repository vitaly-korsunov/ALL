using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.ViewModel
{
    public class ProductVM
    {
        public Product? Product { get; set; }
        /*    
          [ValidateNever]
           public IEnumerable<SelectListItem>? CategoryList  { get; set; }
           [ValidateNever]
           public IEnumerable<SelectListItem>? CoverTypeList { get; set; }
         */
        //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
        //   u => new SelectListItem
        //   {
        //       Text = u.Name,
        //       Value = u.Id.ToString()
        //   });
        //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
        //  u => new SelectListItem
        //  {
        //      Text = u.Name,
        //      Value = u.Id.ToString()
        //  });
    }
}

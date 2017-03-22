using System.Web.Mvc;
using Light.Framework.Core.Imaging;

namespace Light.Framework.Web.Base.ModelBinders
{
    public class Base64ImageBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("base64image");
            if (value == null || string.IsNullOrEmpty(value.AttemptedValue))
            {
                return null;
            }
            return new Base64Image(value.AttemptedValue).Build();
        }
    }
}

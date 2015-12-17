using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Client.Windows.ApplicationUser.LoginFormDecorator.Abstract
{
    public abstract class Decorator
    {
        protected IComponent Component;

        public void SetComponent(IComponent component)
        {
            Component = component;
        }

        public void Operation()
        {
            if(Component!=null)
                Component.Operation();
        }
    }
}

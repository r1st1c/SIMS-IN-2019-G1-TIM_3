using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekat_SIMS_IN_TIM3.Commands
{
    internal class RoutedCommands
    {
        public static readonly RoutedUICommand SignIn = new RoutedUICommand(
            "Hello World",
            "HelloWorld",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter),
            }
        );
    }
}

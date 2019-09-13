using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvisWin.Invis.types;

namespace InvisWin.Invis.core.variables
{
    public class VDate : Variable
    {
        /// <summary>
        /// The variable's value
        /// </summary>
        public object value
        {
            get
            {
                return DateTime.Now.ToLongDateString();
            }
            set
            {
                throw new Exception("You cannot change the date.");
            }
        }

        /// <summary>
        /// Parent of the element.
        /// </summary>
        public Environment parentEnv
        {
            get
            {
                return parentEnv;
            }
            set
            {

            }
        }


        /// <summary>
        /// Initialize the date
        /// </summary>
        /// <param name="environment"></param>
        public VDate(Environment environment)
        {
            this.parentEnv = environment;
        }

    }
}

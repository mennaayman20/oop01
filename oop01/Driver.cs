using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
    public class Driver
    {
        public string Name { get; set; }

        // 2. منشئ الكائن (Constructors)

        // منشئ فارغ
        public Driver()
        {
        }

        // منشئ يستقبل اسم السائق (وهو المعتمد في دالة Main)
        public Driver(string name)
        {
            Name = name;
        }

        // 3. دالة لعرض تفاصيل السائق عند الحاجة
        public override string ToString()
        {
            return $"Driver: {Name}";
        }
    }
}

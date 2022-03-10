﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}

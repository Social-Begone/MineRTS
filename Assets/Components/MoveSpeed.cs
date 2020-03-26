﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

public struct MoveSpeed : IComponentData
{
    public float Value;
}

public class MoveSpeedComponent : ComponentDataProxy<MoveSpeed> { }


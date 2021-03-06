﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DosTerrainImporter.Importer
{
    public abstract class TerrainImporter
    {
        public abstract int getMaximumWriteOperations();

        public abstract void execute(object sender, DoWorkEventArgs e);
    }
}

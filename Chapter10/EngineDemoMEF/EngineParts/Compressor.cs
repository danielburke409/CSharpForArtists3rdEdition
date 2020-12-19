﻿using System;
using System.ComponentModel.Composition; // added

namespace EngineParts
{
    [Export(typeof(Compressor))]
    public class Compressor
    {
        public int EngineNumber
        {
            get;
            set;
        }

        public PartStatus Status
        {
            get;
            set;
        } = PartStatus.WORKING;

        public bool IsWorking
        {
            get
            {
                return Status == PartStatus.WORKING ? true : false;
            }
            set
            {
                if (value) Status = PartStatus.WORKING;
                else Status = PartStatus.NOT_WORKING;
            }
        }

        [ImportingConstructor]
        public Compressor(int engine_number)
        {
            EngineNumber = engine_number;
            Console.WriteLine(this.GetType().Name + " Created!");
        }
    }
}

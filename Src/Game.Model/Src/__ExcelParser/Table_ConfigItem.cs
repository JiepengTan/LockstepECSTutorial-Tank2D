﻿
//------------------------------------------------------------------------------    
// <auto-generated>                                                                 
//     This code was generated by Tools.ExcelParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null. 
//     https://github.com/JiepengTan/LockstepEngine                                          
//     Changes to this file may cause incorrect behavior and will be lost if        
//     the code is regenerated.                                                     
// </auto-generated>                                                                
//------------------------------------------------------------------------------  
using System;
using System.Collections.Generic;
using Lockstep.Serialization;
using Lockstep.Math;

namespace Lockstep.Game{
    public partial class Table_ConfigItem : TableData<Table_ConfigItem>
    {
        const string tableName = "ConfigItem";
        public override string Name() { return tableName; }               
        
        /// id
        public UInt16 asset;        
        /// 
        public Int32 itemType_type;

        protected override void DoParseData(Deserializer reader){ 
            asset = reader.ReadUInt16(); 
            itemType_type = reader.ReadInt32();
        }
    }
}
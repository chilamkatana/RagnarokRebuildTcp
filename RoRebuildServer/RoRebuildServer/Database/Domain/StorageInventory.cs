﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoRebuildServer.Database.Domain;

[Table("StorageInventory")]
public class StorageInventory
{
    [Key] public int Id { get; set; }
    public required byte[] StorageData { get; set; }
    public int UncompressedSize { get; set; }
    public int AccountId { get; set; }
    public int StorageZeny { get; set; }
    public RoUserAccount Account { get; set; } = null!; //auto populated via AccountId
}
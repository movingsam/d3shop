﻿using NetCorePal.D3Shop.Admin.Shared.Dtos.Identity;
using System.ComponentModel.DataAnnotations;

namespace NetCorePal.D3Shop.Admin.Shared.Requests;

public class UpdateDepartmentInfoRequest
{
    [Required] public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<CreateDepartmentUserInfoDto> Users { get; set; } = [];
}
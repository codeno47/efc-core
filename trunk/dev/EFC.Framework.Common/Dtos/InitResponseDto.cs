using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Framework.Common.Dtos
{
    [Serializable]
    public class InitResponseDto
    {
        public Guid Id { get; }

        public InitResponseDto()
        {
            Id = Guid.NewGuid();
        }
    }
}

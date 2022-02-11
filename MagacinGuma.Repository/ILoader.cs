using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Repository
{
    public interface ILoader
    {
        void ShowLoading();
        void HideLoading();
    }
}

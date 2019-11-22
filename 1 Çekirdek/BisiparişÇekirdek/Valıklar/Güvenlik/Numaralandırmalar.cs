using System;
using System.Collections.Generic;
using System.Text;

namespace BisiparişÇekirdek.Valıklar.Güvenlik
{
    public enum KullanıcıRol
    {
        SistemYönetici = 1,
        MüşteriDestekTemsilci,
        İşletmeYönetici,
        İşletmeKullanıcı,
        Müşteri
    }

    public enum KullanıcıSistemDurum
    {
        Aktif = 1,
        Atıl,
        Kaldırıldı
    }
}

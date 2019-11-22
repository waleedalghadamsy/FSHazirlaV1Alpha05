$(function () {
    try {
        alert("Loaded");

        $(".fa-spin").hide();

        kullanıcıGeoLocation();

        $("#ilListe").change(function () {
            try {
                var ilIdJson = $("#ilListe").val();

                //alert(ilPlakaJson);

                $("#ilçeListe").empty();

                var requestUrl = $("#rootDir").val() + "/OrtakKısmi/İlİlçelerAl/" + ilIdJson;

                //alert(requestUrl);

                $.ajax({
                    url: requestUrl,
                    cache: false,
                    type: 'GET',
                    data: { ilId: ilIdJson },
                    async: true
                }).
                    done(function (r) {
                        try {
                            //alert("Done"); alert(r);

                            $.each(r, function (idx, vl) {
                                //alert(vl);
                                $('#ilçeListe').append(vl);
                            });
                        } catch (e) {
                            alert("Done error");
                        }
                    }).
                    fail(function (err) {
                        alert('Fail Error: ' + err.message);
                    });
            } catch (e) {
                alert("Main function error");
            }
        });

        $("#ilçeListe").change(function () {
            try {
                var ilIdJson = $("#ilListe").val(); var ilçeIdJson = $("#ilçeListe").val();

                //alert(ilçeIdJson);

                $("#semtMahalleListe").empty();

                //var requestUrl = $("#rootDir").val() + "/OrtakKısmi/İlçeSemtlerAl/" + ilçeIdJson;
                var requestUrl = $("#rootDir").val() + "/OrtakKısmi/İlçeSemtlerVeMahallelerAl/" + ilçeIdJson;

                //alert(requestUrl);

                $.ajax({
                    url: requestUrl,
                    cache: false,
                    type: 'GET',
                    data: { ilçeId: ilçeIdJson },
                    async: true
                }).
                    done(function (r) {
                        try {
                            //alert("Done"); alert(r);

                            $.each(r, function (idx, vl) {
                                //alert(vl);
                                $('#semtMahalleListe').append(vl);
                            });
                        } catch (e) {
                            alert("Done error");
                        }
                    }).
                    fail(function (err) {
                        alert('Fail Error: ' + err.message);
                    });
            } catch (e) {
                alert("Main function error");
            }
        });

        $("#semtListe").change(function () {
            try {
                //var ilIdJson = $("#ilListe").val(); var ilçeIdJson = $("#ilçeListe").val();
                var semtIdJson = $("#semtListe").val();

                //alert(semtIdJson);

                $("#mahalleListe").empty();

                var requestUrl = $("#rootDir").val() + "/OrtakKısmi/SemtMahallelerAl/" + semtIdJson;

                //alert(requestUrl);

                $.ajax({
                    url: requestUrl,
                    cache: false,
                    type: 'GET',
                    data: { semtId: semtIdJson },
                    async: true
                }).
                    done(function (r) {
                        try {
                            //alert("Done"); alert(r);

                            $.each(r, function (idx, vl) {
                                //alert(vl);
                                $('#mahalleListe').append(vl);
                            });
                        } catch (e) {
                            alert("Done error");
                        }
                    }).
                    fail(function (err) {
                        alert('Fail Error: ' + err.message);
                    });
            } catch (e) {
                alert("Main function error");
            }
        });

        $("#ResimDosyalar").change(function () {
            try {
                //alert("Into change");

                var rsmDsylr = $("#ResimDosyalar")[0].files;

                //alert("Found: " + rsmDsylr.length);

                $("#resimSıra").empty();

                for (var i = 0; i < rsmDsylr.length; i++) {
                    var reader = new FileReader();
                    reader.readAsDataURL(rsmDsylr[i]);
                    reader.onloadend = function () {
                        var kçkRsm = document.createElement("img");
                        kçkRsm.width = 40; kçkRsm.height = 40; kçkRsm.style = "border:1px ;margin-top:10px; margin-left:10px;";
                        kçkRsm.src = this.result;

                        var tdElm = document.createElement("td"); tdElm.appendChild(kçkRsm);

                        $("#resimSıra").append(tdElm);
                    };
                }
            } catch (e) {
                alert("Upload change error");
            }
        });
    } catch (e) {
        alert(e.message);
    }
});

function semtMhlSeçildi(v) {
    try {
        //alert(v);
        $("#semtMhlId").val(v);
    } catch (e) {
        alert(e.message);
    }
};

function hizmetSeçildi(v, strV) {
    try {
        //alert("Hizmet checkbox");

        var isChecked = $('input:checkbox[name=' + strV + 'Chk]').is(':checked');

        //alert(v); alert($("#rstrHizmetler").val());// alert("Int Val: " + hizmetDeğer);

        //alert(BigInt(chkbx.val()));
        var hizmetDeğer = BigInt(v); var seçildiHizmetler = BigInt($("#rstrHizmetler").val());

        //alert("Int Val: " + hizmetDeğer); alert("Int Val: " + seçildiHizmetler);

        if (isChecked) {
            $("#rstrHizmetler").val(seçildiHizmetler | hizmetDeğer);
        }
        else {
            $("#rstrHizmetler").val(seçildiHizmetler | ~hizmetDeğer);
        }
    } catch (e) {
        alert(e.message);
    }
};

function mutfakSeçildi(v, strV) {
    try {
        //alert("Mutfak checkbox checked");

        var isChecked = $('input:checkbox[name=' + strV + 'Chk]').is(':checked');

        //alert(v); alert($("#rstrMutfaklar").val());// alert("Int Val: " + hizmetDeğer);

        //alert(BigInt(chkbx.val()));
        var mtfkDeğer = BigInt(v); var seçildiMutfaklar = BigInt($("#rstrMutfaklar").val());

        //alert("Int Val: " + hizmetDeğer); alert("Int Val: " + seçildiHizmetler);

        if (isChecked) {
            $("#rstrMutfaklar").val(seçildiMutfaklar | mtfkDeğer);
        }
        else {
            $("#rstrMutfaklar").val(seçildiMutfaklar | ~mtfkDeğer);
        }
    } catch (e) {
        alert(e.message);
    }
};

function kullanıcıGeoLocation() {
    try {
        //alert("Trying to get geo loc...");

        var mapOptions = {
            center: new google.maps.LatLng(41.0055005, 28.7319867), //İstanbul
            zoom: 10,
            minZoom: 10,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        var map = new google.maps.Map(document.getElementById('restoranKonumHarita'), {
            center: { lat: -34.397, lng: 150.644 },
            zoom: 6
        });

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };

                map.setCenter(pos); $("#restoranKonumHarita").show();

                //alert("Geo loc OK");
            }, function (posErr) {
                alert("Error while getting geo loc: " + posErr.message);
                map.setOptions(mapOptions);
                //Istanbul coord: 41.0055005,28.7319867
            });
        } else {
            alert("Browser doesn't support Geolocation");
            map.setOptions(mapOptions);
            //Istanbul coord: 41.0055005,28.7319867
        }
    } catch (e) {

    }
};

function gösterGoogleMap() {
    try {

        var theMapUrl = $("#haritaUrl").val();
        var requestUrl = $("#rootDir").val() + "/GoogleMaps/KoordinatlarAl?url=" + theMapUrl;
        //var requestUrl = $("#rootDir").val() + "/GoogleMaps/Example";//+ theMapUrl;

        //alert("Calling: " + requestUrl);

        $.ajax({
            url: requestUrl,
            cache: false,
            type: 'GET',
            //data: { 'url': theMapUrl },
            async: true
        }).
            done(function (r) {
                try {
                    //alert("Done"); alert(r); alert(r[0]); alert(r[1]);

                    //var koords = r.split(","); alert(koords[0]); alert(koords[1]);

                    displayMap(r[0], r[1]);
                } catch (e) {
                    alert("Done error");
                }
            }).
            fail(function (err) {
                alert('Fail Error: ' + err.message);
            });

    } catch (e) {

    }
};

function displayMap(lat, lng) {
    try {
        //alert("Into Display...");

        //Set the Latitude and Longitude of the Map
        var myAddress = new google.maps.LatLng(lat, lng);

        //Create Options or set different Characteristics of Google Map
        var mapOptions = {
            center: myAddress,
            zoom: 15,
            minZoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        //alert("Getting map...");

        //Display the Google map in the div control with the defined Options
        var map = new google.maps.Map(document.getElementById("restoranKonumHarita"), mapOptions);

        //Set Marker on the Map
        var marker = new google.maps.Marker({
            position: myAddress,
            animation: google.maps.Animation.BOUNCE,
        });

        //alert("Setting map...");

        marker.setMap(map); $("#restoranKonumHarita").show();

        var krdtlr = map.LatLng.lat.toString() + "," + map.LatLng.lng.toString();

        $("#rstrnKrdtlr").val(krdtlr);
    } catch (e) {
        alert('Display Error: ' + e.message);
    }
};

$("#rstrnForm").submit(function () {
    try {
        alert("Handler for .submit() called.");

        çalışmaZamanlarKoleksiyonaKoy();

        $("#kaydetBtn").attr("disabled", "disabled");
        $(".fa-spin").show();
        //event.preventDefault();
    } catch (e) {
        alert(e.message);
    }
});

function çalışmaZamanlarKoleksiyonaKoy() {
    try {
        alert("Collecting...");

        $("#rstrÇlşmZmnlar").val(JSON.stringify(
            [
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 1,
                    "Saatten": $("#pzrtStn").val(), "Saate": $("#pzrtSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=pzrtGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 2,
                    "Saatten": $("#salStn").val(), "Saate": $("#salSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=salGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 3,
                    "Saatten": $("#çrşStn").val(), "Saate": $("#çrşSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=çrşGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 4,
                    "Saatten": $("#prşStn").val(), "Saate": $("#pzrtSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=prşGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 5,
                    "Saatten": $("#pzrtStn").val(), "Saate": $("#prşSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=pzrtGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 6,
                    "Saatten": $("#cumStn").val(), "Saate": $("#cumSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=cumGün]').is(':checked')
                },
                {
                    "Id": "0", "AktifMi": "true", "Oluşturulduğunda": "null", "OluşturuKimsiId": "0", "İşletmeId": "0",
                    "HaftaGün": 0,
                    "Saatten": $("#cmrtStn").val(), "Saate": $("#cmrtSte").val(),
                    "HaftaGünSeçildi": $('input:checkbox[name=cmrtGün]').is(':checked')
                }
            ]));

        alert($("rstrÇlşmZmnlar").val());
    } catch (e) {
        alert(e.message);
    }
};

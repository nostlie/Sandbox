/// <reference path="../lib/jquery-1.9.1.min.js" />
'use strict';

/* Services */


// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('PhoneApp.services', ['ngResource']).
    factory('PhoneService', function () {        
        var phones = [{ id: "1", name: "Dell Streak 7", img: "../app/img/dell-streak-7.jpg", description: "Introducing Dell\u2122 Streak 7. Share photos, videos and movies together. It\u2019s small enough to carry around, big enough to gather around. Android\u2122 2.2-based tablet with over-the-air upgrade capability for future OS releases.  A vibrant 7-inch, multitouch display with full Adobe\u00ae Flash 10.1 pre-installed.  Includes a 1.3 MP front-facing camera for face-to-face chats on popular services such as Qik or Skype.  16 GB of internal storage, plus Wi-Fi, Bluetooth and built-in GPS keeps you in touch with the world around you.  Connect on your terms. Save with 2-year contract or flexibility with prepaid pay-as-you-go plans" },
        { id: "2", name: "Dell Venue", img: "../app/img/dell-venue.jpg", description: "The Venue is the perfect one-touch, Smart Phone providing instant access to everything you love. All of Venue's features make it perfect for on-the-go students, mobile professionals, and active social communicators who love style and performance.\n\nElegantly designed, the Venue offers a vibrant, curved glass display that\u2019s perfect for viewing all types of content. The Venue\u2019s slender form factor feels great in your hand and also slips easily into your pocket.  A mobile entertainment powerhouse that lets you download the latest tunes from Amazon MP3 or books from Kindle, watch video, or stream your favorite radio stations.  All on the go, anytime, anywhere." },
        { id: "3", name: "Droid 2", img: "../app/img/droid-2-global-by-motorola.jpg", description: "Adobe Flash Player 10, Quadband GSM Worldphone, Advance Business Security, Complex Password Secure, Review & Edit Documents with Quick Office, Personal 3G Mobile Hotspot for up to 5 WiFi enabled Devices, Advanced Social Networking brings all social content into a single homescreen widget" }];

        return {
            getPhone: function (id) {
                return phones.filter(function (phone) {
                    if (phone.id == id) return phone;
                })[0];
            }
        }
    });

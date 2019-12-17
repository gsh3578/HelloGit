using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;

namespace SpeechAI
{
    [
        XmlRootAttribute("rss")
    ]
    public class RSS
    {
        private String __version;
        private List<Channel> __channels;

        public RSS() : base() { }

        [
            XmlAttributeAttribute("version")
        ]
        public String Version
        {
            get
            {
                return __version;
            }
            set
            {
                __version = value;
            }
        }

        [
            XmlElementAttribute("channel")
        ]
        public List<Channel> Channels
        {
            get
            {
                if (null == __channels)
                {
                    __channels = new List<Channel>();
                }

                return __channels;
            }
            set
            {
                __channels = value;
            }
        }
    }

    [
        XmlTypeAttribute("channel")
    ]
    public class Channel
    {
        private String __title;
        private String __link;
        private String __description;
        private String __lastBuildDate;
        private Int32 __total;
        private Int32 __start;
        private Int32 __display;

        private List<Item> __items;

        public Channel() : base() { }

        [
            XmlElementAttribute("title")
        ]
        public String Title
        {
            get
            {
                return __title;
            }
            set
            {
                __title = value;
            }
        }

        [
            XmlElementAttribute("link")
        ]
        public String Link
        {
            get
            {
                return __link;
            }
            set
            {
                __link = value;
            }
        }

        [
            XmlElementAttribute("description")
        ]
        public String Description
        {
            get
            {
                return __description;
            }
            set
            {
                __description = value;
            }
        }

        [
            XmlElementAttribute("lastBuildDate")
        ]
        public String LastBuildDate
        {
            get
            {
                return __lastBuildDate;
            }
            set
            {
                __lastBuildDate = value;
            }
        }

        [
            XmlElementAttribute("total")
        ]
        public Int32 Total
        {
            get
            {
                return __total;
            }
            set
            {
                __total = value;
            }
        }

        [
            XmlElementAttribute("start")
        ]
        public Int32 Start
        {
            get
            {
                return __start;
            }
            set
            {
                __start = value;
            }
        }

        [
            XmlElementAttribute("display")
        ]
        public Int32 Display
        {
            get
            {
                return __display;
            }
            set
            {
                __display = value;
            }
        }

        [
            XmlElementAttribute("item")
        ]
        public List<Item> Items
        {
            get
            {
                if (null == __items)
                {
                    __items = new List<Item>();
                }

                return __items;
            }
            set
            {
                __items = value;
            }
        }
    }

    [
        XmlTypeAttribute("item")
    ]
    public class Item
    {
        private String __title;
        private String __link;
        private String __description;

        public Item() : this(String.Empty, String.Empty, String.Empty) { }

        public Item(String title, String link, String description)
            : base()
        {
            __title = title;
            __link = link;
            __description = description;
        }

        [
            XmlElementAttribute("title")
        ]
        public String Title
        {
            get
            {
                return __title;
            }
            set
            {
                __title = value;
            }
        }

        [
            XmlElementAttribute("link")
        ]
        public String Link
        {
            get
            {
                return __link;
            }
            set
            {
                __link = value;
            }
        }

        [
            XmlElementAttribute("description")
        ]
        public String Description
        {
            get
            {
                return __description;
            }
            set
            {
                __description = value;
            }
        }
    }
}
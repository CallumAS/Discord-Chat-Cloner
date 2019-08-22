using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Chat_Cloner.Core.DataModels
{
    public struct Author
    {
        public string username { get; set; }
        public string discriminator { get; set; }
        public string id { get; set; }
        public string avatar { get; set; }
    }
    public struct Attachment
    {
        public ulong Id { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public string ProxyUrl { get; set; }
        public int Size { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
    #region Embed
    public struct Embed
    {
        string Url { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        EmbedType Type { get; set; }
        DateTimeOffset? Timestamp { get; set; }
        Color? Color { get; set; }
        EmbedImage? Image { get; set; }
        EmbedVideo? Video { get; set; }
        EmbedAuthor? Author { get; set; }
        EmbedFooter? Footer { get; set; }
        EmbedProvider? Provider { get; set; }
        EmbedThumbnail? Thumbnail { get; set; }
        EmbedField[] Fields { get; set; }
    }
    public struct EmbedField
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Inline { get; set; }
    }
    public struct EmbedProvider
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public struct EmbedVideo
    {
        public string Url { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
    public enum EmbedType
    {
        Unknown = -1,
        Rich,
        Link,
        Video,
        Image,
        Gifv,
        Article,
        Tweet,
        Html,
    }
    public struct EmbedThumbnail
    {
        public string Url { get; set; }
        public string ProxyUrl { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
    public struct EmbedImage
    {
        public string Url { get; set; }
        public string ProxyUrl { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
    public struct EmbedFooter
    {
        public string Text { get; set; }
        public string IconUrl { get; set; }
        public string ProxyUrl { get; set; }
    }
    public struct EmbedAuthor
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public string ProxyIconUrl { get; set; }
    }
    #endregion
    public struct Message
    {
        public List<Attachment> attachments { get; set; }
        public bool tts { get; set; }
        public List<Embed> embeds { get; set; }
        public DateTime timestamp { get; set; }
        public bool mention_everyone { get; set; }
        public string id { get; set; }
        public bool pinned { get; set; }
        public object edited_timestamp { get; set; }
        public Author author { get; set; }
        public List<object> mention_roles { get; set; } //Not Required
        public string content { get; set; }
        public string channel_id { get; set; }
        public List<object> mentions { get; set; }      //Not Required
        public int type { get; set; }
    }
}

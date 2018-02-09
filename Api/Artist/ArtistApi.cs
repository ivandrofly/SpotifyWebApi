// <copyright file="ArtistApi.cs" company="companyPlaceholder">
// Copyright (c) companyPlaceholder. All rights reserved.
// </copyright>

namespace SpotifyWebApi.Api.Artist
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;
    using Model.Auth;
    using Model.Enum;
    using Model.Uri;

    /// <summary>
    /// The <see cref="ArtistApi"/>.
    /// </summary>
    public class ArtistApi : BaseApi, IArtistApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistApi"/> class.
        /// </summary>
        public ArtistApi(Token token) : base(token)
        {
        }

        /// <inheritdoc />
        public FullArtist GetArtist(SpotifyUri artistUri)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IList<FullArtist> GetArtists(IList<SpotifyUri> artistUris)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Paging<SimpleAlbum> GetArtistAlbums(
            SpotifyUri artistUri,
            AlbumType albumTypes = AlbumType.Album | AlbumType.AppearsOn | AlbumType.Compilation | AlbumType.Single,
            string market = "",
            int limit = 20,
            int offset = 0)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IList<FullTrack> GetArtistsTopTracks(SpotifyUri artistUri, string market)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IList<FullArtist> GetArtistsRelatedArtists(SpotifyUri artistUri)
        {
            throw new NotImplementedException();
        }
    }
}
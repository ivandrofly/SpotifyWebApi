namespace SpotifyWebApi.Api.Playlist
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business;
    using Model;
    using Model.Auth;
    using Model.Uri;

    /// <summary>
    /// The <see cref="PlaylistApi"/>.
    /// </summary>
    public class PlaylistApi : BaseApi, IPlaylistApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistApi"/> class.
        /// </summary>
        /// <param name="token">A valid <see cref="Token"/>.</param>
        public PlaylistApi(Token token)
            : base(token)
        {
        }

        /// <inheritdoc />
        public async Task<IList<SimplePlaylist>> GetUsersPlaylist(SpotifyUri user, int maxResults, int offset = 0)
        {
            var r = await ApiClient.GetAsync<Paging<SimplePlaylist>>(
                        MakeUri($"users/{user.Id}/playlists?limit=50&offset={offset}"), this.Token);

            if (r.Response is Paging<SimplePlaylist> res)
            {
                return await res.LoadToList(this.Token, maxResults);
            }
            return new List<SimplePlaylist>();
        }

        /// <inheritdoc />
        public async Task<IList<SimplePlaylist>> GetMyPlaylists(int maxResults, int offset = 0)
        {
            var r = await ApiClient.GetAsync<Paging<SimplePlaylist>>(
                        MakeUri($"me/playlists?limit=50&offset={offset}"), this.Token);

            if (r.Response is Paging<SimplePlaylist> res)
            {
                return await res.LoadToList(this.Token, maxResults);
            }
            return new List<SimplePlaylist>();
        }

        /// <inheritdoc />
        public async Task<FullPlaylist> GetPlaylist(SpotifyUri playlistUri, string market)
        {
            var r = await ApiClient.GetAsync<FullPlaylist>(
                        MakeUri(
                            $"playlists/{playlistUri.Id}",
                                ("market", market)),
                        this.Token);

            if (r.Response is FullPlaylist res)
            {
                return res;
            }

            return new FullPlaylist();
        }

        /// <inheritdoc />
        public async Task<IList<PlaylistTrack>> GetPlaylistTracks(
            SpotifyUri playlistUri, int maxResults, int offset, string market)
        {
            var r = await ApiClient.GetAsync<Paging<PlaylistTrack>>(
                        MakeUri(
                            $"playlists/{playlistUri.Id}/tracks?limit=100&offset={offset}",
                            ("market", market)),
                        this.Token);

            if (r.Response is Paging<PlaylistTrack> res)
            {
                return await res.LoadToList(this.Token, maxResults);
            }
            return new List<PlaylistTrack>();
        }

        /// <inheritdoc />
        public async Task<FullPlaylist> CreatePlaylist(
            SpotifyUri user, string name, bool @public, string description)
        {
            var r = await ApiClient.PostAsync<FullPlaylist>(
                MakeUri($"users/{user.Id}/playlists"),
                new PlaylistCreate
                {
                    Name = name,
                    Public = @public,
                    Description = description,
                }, this.Token);

            if (r.Response is FullPlaylist playlist)
            {
                return playlist;
            }
            return new FullPlaylist();
        }

        /// <inheritdoc />
        public Task AddTracksToPlaylist(SpotifyUri playlistUri, IList<SpotifyUri> tracks, int? position = null)
        {
            throw new NotImplementedException();
        }
    }
}

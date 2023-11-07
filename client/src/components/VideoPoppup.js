import React, { useState } from 'react'
import YouTube from 'react-youtube'

export const VideoPopup = (props) => {

  const [player, setPlayer] = useState()

  return (
    <React.Fragment>
      <YouTube
        ref={player}
        videoId={'HqGsT6VM8Vg'}
        onStateChange={(e) => {
          setPlayer(e.target)
        }}
        opts={{ playerVars: { rel: 0, modestbranding: 1, loop: 1 } }}
      />
    </React.Fragment>
  )
}

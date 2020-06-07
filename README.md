# Getting Started

1. Install version `2019.3.15f1` of Unity.

It's very important that we're all using the same version of Unity,
and this is the one that we'll be sticking to for the project. If a new version comes out and there's
a reason to upgrade we can, but once we've leapt forward, there's no going back.

Luckily, Unity Hub makes it super easy to manage different versions of Unity. If you already have a different
version installed, you can go to the `Installs` tab, click `Add`, and select the version indicated above. After
having installed it, you'll now be able to open up our project.

2. Install Git LFS.

Out of the box, Git isn't great at tracking files that are
really large or encoded in non-human-readable formats. An add-on called Git Large File Storage (LFS) goes a long way towards solving those
problems, and our project is configured to use it for all files Unity spits out that don't fit the mold of what
Git traditionally is good at tracking.

Go [here](https://git-lfs.github.com/), download the appropriate version for your OS, unpack the tarball (or unzip the zip), and run the install script. If you're on a Mac and use Homebrew, you can also just `brew install git-lfs`.

Once LFS is installed on your system, run `git lfs install` from the command line to configure it for your current user.

3. Clone this repository
4. Open the repository in Unity

In Unity Hub, you'll go to the `Projects` tab, click the `Add` button, and select the cloned git repository.

5. Build a cool game
6. ???
7. $$
   $$

# Cool Facts for Cool Kids

- When it comes to building out levels in Unity, there are several different approaches that people take according to the specific needs of the game they're building.
  > - _Common Approach A_: Create a different scene for each level
  > - _Common Approach B_: Use a single scene for the whole game

We are going to follow approach _B_; since our game is going to be wave-based and dead simple to start, each level is going to be the same formula with inputs that make the levels harder and harder as the player progresses. Building out a new scene for each wave would be ludicrous; instantiating each wave programmatically makes way more sense.

There are a couple of other good reasons for going this route as well that I'm happy to talk about if anyone is curious. With all of that being said, all permanent work we do will be in the `Main` scene (but my noob Unity brain intuits that it would be perfectly _dandy_ for people to build out their own scenes to iterate and test their own features in).

- The settings of our project tell Unity to store everything in text files.

This is great, because it makes things much simpler for tracking with Git. If we wanted to, we could technically build out our entire game using the Unity Engine without using the Unity Editor by hand editing lovely YAML files that look like this:

```yaml
--- !u!4 &8
Transform:
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 0}
  m_GameObject: {fileID: 6}
  m_LocalRotation: {x: 0.000000, y: 0.000000, z: 0.000000, w: 1.000000}
  m_LocalPosition: {x: -2.618721, y: 1.028581, z: 1.131627}
  m_LocalScale: {x: 1.000000, y: 1.000000, z: 1.000000}
  m_Children: []
  m_Father: {fileID: 0}
```

If you're a nerd that wants to read more about how Unity is storing stuff in our project, you can read about it [on this doc page](https://docs.unity3d.com/Manual/FormatDescription.html).

- Make sure to save your project AND save the scene prior to staging and committing changes.

This could be a gotcha if you're not careful. Since Unity compartmentalizes Game Objects on a per-scene basis, and all scenes are part of a project, failing to properly save EVERYTHING could result in your work not getting included in git like you think it is.

Anytime that you're going to push changes, make sure you save the _Project_ (`File`->`Save Project`) AND the _Scene_ (`Right click on scene in Hierarchy`->`Save Scene` or `Command + s` / `Control + s`)

- We're all so new at this that I think it's okay (encouraged, actually) to fly by the seat of our pants for v1.

To me, that means: we all push to the `master` branch (just no force pushing since that'll mean someone loses their work), we don't do code reviews, and we don't really care about organizing stuff.

In some sort of v2 or v3 of our game where we add complexity we might start worrying about following "best practices" and trying to be a lil tighter, but for now we should enjoy being [young, wild, and free](https://www.youtube.com/watch?v=Wa5B22KAkEk).

# Closing Thoughts

ily guys <3

![haha alt text OKAY](https://media.giphy.com/media/5kq0GCjHA8Rwc/giphy.gif)

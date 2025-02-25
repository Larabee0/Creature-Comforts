// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]

“Hello again, don’t suppose you’ve heard any word in regards to my missing persons case?” # s Mothman # b 1 # a 3 # h 2

<i>The desk hasn’t exactly been too busy with briefcase wielding guests. No rogue literature has been miraculously recovered.
</i> # s You

"No. I'm afraid not."

“<i>Wonderful.</i>” # s Mothman # h 1
“With that lovely news now confirmed, I’ll be expecting a call. Please forward it to my room.” # b 2 # a 2 # h 2

“Of course, but I’m going to need to take down a name, Motel policy.” # s You # h 10

<i>He seems briefly annoyed at this personal intrusion. You can’t help but be a little excited at the chance to gain more information on this scenario.</i>

“Fine. It will be coming from an associate of P. Pleasant Publishing.” # s Mothman # h 1
“They will be wanting to hear about my current…<i>situation</i>." # b 1 # a 1 # h 2
"Hopefully the disappearance of my Manager will overshadow any anger over my little side trip.” # h 5

<i>He pauses to sigh. Doesn’t seem like this vacation is going very smoothly.</i> # s You # h 11

“Oh, and if Aubrey does somehow manage to call, please tell them I am very disappointed in their directional abilities and we will be exchanging strong words.” # s Mothman # h 4 # b 2 # a 2

<i>Despite the anger evident in his voice, he seems oddly pleased about the loss of Aubrey.</i> # s You

“Might be worth breaking the bad news yourself in advance. Getting lost along with my latest bestseller is not a good look for them.” # b 1 # a 3 # h 6
“After our little chat has concluded, they are most definitely being fired.” # h 3

<i>You can’t deny being intrigued by this turn of events. Unlucky Aubrey… or judging by the sudden undertone of glee in his voice, maybe they deserved it.</i> # s You

*[ “So… Press Manager, huh? What was Aubrey like?”] -> manager1
*[“I’ll let you know if anyone calls!”] -> manager2

=== manager1 ===
“<i>Former Manager</i>, would be a more polite way to phrase it now, I suppose.” # s Mothman # h 2 # b 2 # a 2
“Whilst I do hope nothing bad has befallen them, I must say that it is a rather fortunate turn of events they won’t be staying during my holiday.” # h 3
“It was already a chore convincing them to let me come here for a couple days at all.” # h 1
“We often do not get along, even at the best of times. Opposing views on genre and such. ” # h 5 # b 2 # a 2
 “They bend to my publishers every whim. This incident will not do wonders to improve relations with them.” # h 1
“<i>Especially</i> if Aubrey happens to find their way here after all…” # h 11
“Also… they were very… how can I phrase this politely… <i>loud</i>.” # h 1

-> job

=== manager2 ===
“Thank you. I wouldn't suspect it would be before tomorrow morning, but just in case.” # s Mothman # h 2 # b 2 # a 2

-> job

=== job ===
“It’s really important I deal with this as soon as possible as it could put some strain on my career when I return from this little trip.” # s Mothman # b 2 # a 2 # h 5

“What do you do?” # s You

“Was it not obvious from my previous statements? I’m an author, but I prefer to use the term novelist.” # s Mothman # h 9 # b 1 # a 1

<i>You can’t help but laugh at his hubris. Are they really that recognizable?</i> # s You

*[“Come to think of it, your name does ring a bell.”] -> known1
*[“Never heard of you.”] -> known2

=== known1 ===
“I rather think it should! M. Mothman is a household staple.” # s Mothman # h 10
“For connoisseurs of historical fiction, that is…” # h 3
“I’ve written such classics as <i>‘The Dawning of the Lamp’</i> and <i>‘Beyond the Forest Trees Part 2 featuring new Addendums'."</i> # h 9
“In fact, right at this very moment I’m working on my greatest work yet! # h 6
“...which is completely a secret… why on earth am I telling <i>you?!</i>” # b 2 # a 2 # h 7

<i>You decide to let him keep spouting book related words at you as he goes into a frenzy trying to cover up what he just let slip. </i> # s You # b 1 # a 3 # h 8
<i>None of the titles instill any sort of recognition whatsoever.</i>

-> sc2end

=== known2 ===
<i> He stares at you in mock offence. Silent. This is awkward… </i> # s Mothman # h 7
“Never…heard…of…me??” 
“You must be lying. I can’t believe it! Either that, or you have no taste.” # h 10
“It seems I’ve come to expect that from this reception.” # h 11
“<i>Never</i> heard of me… honestly, I’m a <i>multi award winning bestseller.</i> Look me up.” # h 8
 -> sc2end
 
=== sc2end ===
“Anyway, enough about my inimitable career. I have a fresh manuscript to review in my room that suddenly seems <i>infinitely</i> more interesting than this conversation. Adieu.” # s Mothman # h 2 # b 2 # a 2
<i>Well, he sure is a 'conversationalist'. Make sure to keep an eye out for any phone calls. </i> # s You # b 0 # a 0 # h 0
-> END

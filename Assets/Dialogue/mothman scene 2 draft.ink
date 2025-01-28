// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// e        = end tag

"Hello again, don't suppose you've heard any word?" # s Mothman #b 1 # a 3 # h 2

<i>You decline to mention the fact you were never very sure who to look for in the first place.</i> # s You

"No. Afraid not."

“Wonderful.” # s Mothman
“I’m expecting a call, please forward it to my room.”

“I’m going to need to take down a name please.” # s You

“Fine. It should be an associate of P. Pleasant Publishing.” # s Mothman
“They will be wanting to hear about this situation.”

<i>He pauses to sigh. Doesn’t seem like this vacation is going very smoothly.</i>

“Oh, and if anyone phones under the name Aubrey, please tell them I am very disappointed in them right now.”
“Might be worth breaking the news yourself honestly, instead of myself."
“They are most definitely fired.”

<i>You can’t deny being intrigued by this turn of events.</i> # s You

*[“Is Aubrey your manager?”] -> manager1
*[“I’ll let you know if anyone calls!”] -> manager2

=== manager1 ===
“<i>Was</i> my manager, is a more polite way to put it I suppose.” # s Mothman
“Whilst I do hope they haven’t befallen any harm, I must say that it is rather fortunate they didn’t make it here with me.”
“We often do not get on. Opposing views and such. Also they were very loud.”
“This incident will not do wonders to improve my managerial relations.” 
“<i>Especially</i> if Aubrey happens to find their way here after all…”
-> job

=== manager2 ===
“Thank you. I wouldn't suspect it would be before tomorrow morning, but just in case.” # s Mothman
-> job

=== job ===
“It’s really important I deal with this as soon as possible.” # s Mothman
“It could put some strain on my career whilst I am on this little trip.”

“What do you do?” # s You

“Was it not obvious from my questioning? I’m an author, but I prefer the term novelist.” # s Mothman

<i>You can’t help but laugh at his hubris.</i> # s You

*[“Come to think of it, your name does ring a bell.”] -> known1
*[“Never heard of you.”] -> known2

=== known1 ===
“I rather think it should! M. Mothman is a household staple.” # s Mothman
“If you read historical fiction, that is…”
“I’ve written such classics as <i>‘The Dawning of the Lamp’</i> and <i>‘Beyond the Forest Trees Part 2 featuring new Addendums."</i>

<i>You decide to let him keep spouting book titles at you. None of them instill any sort of recognition whatsoever.</i> # s You
-> sc2end

=== known2 ===
<i> He stares at you in mock offence. Silent. This is awkward… </i> # s Mothman
“Never…heard…of…me??”
“You must be lying. I can’t believe it! Either that, or you have no taste.”
“It seems I’ve come to expect that from this reception.”
 “I’m a multi award winning bestseller. Look me up.”
 -> sc2end
=== sc2end ===
“Anyway, enough about my infinitely successful career. I have a draft to review in my room that suddenly seems infinitely more interesting than this conversation. Adieu.” # s Mothman
<i>Well, he sure is a conversationalist. Make sure to keep an eye out for any phone calls. </i> # s You
-> END